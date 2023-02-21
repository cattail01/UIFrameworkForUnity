using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI MVC view base class
/// </summary>
/// <remarks>
/// <para>
/// notice 1: this class has better not extend MonoBehavior, for Easy-Using and Easy-Hotfix
/// </para>
/// </remarks>
public class ViewBase
{
    #region Variables

    /// <summary>
    /// transform of UI game object
    /// </summary>
    protected Transform transform;

    /// <summary>
    /// transform of UI game object
    /// </summary>
    public Transform Transform
    {
        get => transform;
        set => transform = value;
    }

    /// <summary>
    /// assert name of ui view
    /// </summary>
    protected string assertName;

    /// <summary>
    /// assert name of ui view
    /// </summary>
    public string AssertName
    {
        get => assertName;
        set => assertName = value;
    }

    /// <summary>
    /// is view permanent
    /// </summary>
    protected bool isPermanent = false;

    /// <summary>
    /// is view permanent
    /// </summary>
    public bool IsPermanent
    {
        get => isPermanent;
        protected set => isPermanent = value;
    }

    /// <summary>
    /// is UI view visitable
    /// </summary>
    protected bool isVisitable = false;

    /// <summary>
    /// is UI view visitable
    /// </summary>
    public bool IsVisitable
    {
        get => isVisitable;
        protected set => isVisitable = value;
    }

    /// <summary>
    /// view type
    /// </summary>
    protected ViewType viewType;

    /// <summary>
    /// view type
    /// </summary>
    public ViewType ViewType
    {
        get => viewType;
        protected set => viewType = value;
    }

    /// <summary>
    /// scene type
    /// </summary>
    protected ScenesType scenesType;

    public ScenesType ScenesType
    {
        get => scenesType;
        protected set => scenesType = value;
    }

    /// <summary>
    /// view state type
    /// </summary>
    protected ViewStateType viewStateType;

    /// <summary>
    /// view state type
    /// </summary>
    public ViewStateType ViewStateType
    {
        get => viewStateType;
        set => viewStateType = value;
    }

    /// <summary>
    /// a list of button in view
    /// </summary>
    protected List<Button> buttons;

    /// <summary>
    /// a list of button in view
    /// </summary>

    public List<Button> Buttons
    {
        get => buttons;
        protected set => buttons = value;
    }

    #endregion Variables

    #region Api

    /// <summary>
    /// initialize UI view
    /// </summary>
    /// <remarks>
    /// <para>
    /// notice: if we want to find Button components in children,
    /// we should find them in inactive
    /// </para>
    /// </remarks>
    public virtual void InitView()
    {
        //buttons = new List<Button>(transform.GetComponentsInChildren<Button>(true));
        if(buttons == null)
            buttons = new List<Button>();
        buttons.AddRange(transform.GetComponentsInChildren<Button>(true));
    }

    /// <summary>
    /// register ui event
    /// </summary>
    public virtual void RegisterUIEvent()
    {
        // do something in subclass
    }

    /// <summary>
    /// on add UI event listener
    /// </summary>
    public virtual void OnAddUIEventListener()
    {
        // do something in subclass
    }

    /// <summary>
    /// on remove UI event listener
    /// </summary>
    public virtual void OnRemoveUIEventListener()
    {
        // do something in subclass
    }

    /// <summary>
    /// open UI action 
    /// </summary>
    public virtual void OnEnable()
    {
        // do something in subclass
    }

    /// <summary>
    /// close UI action
    /// </summary>
    public virtual void OnDisable()
    {
        // do something in subclass
    }

    /// <summary>
    /// update UI element pre frame
    /// </summary>
    /// <param name="deltaTime">duration between both frame</param>
    public virtual void OnUpdate(float deltaTime)
    {
        // do something in subclass
    }

    #endregion Api

    #region View Manager

    /// <summary>
    /// open view
    /// </summary>
    public virtual void Open()
    {
        // if transform is null, create view game object
        if(transform == null)
        {
            bool CreateViewSuccess = Create();
        }
        // if view game object is inactive
        // set view state type is active
        // and set parent is object <WorkStation>
        // and enable view game object, set visitable property true
        // do OnEnable and OnAddUIEventListener action to enable view script and add event listener
        if (!transform.gameObject.activeSelf)
        {
            viewStateType = ViewStateType.Activated;
            UIRoot.SetParent(transform, viewStateType);
            isVisitable = true;
            OnEnable();
            OnAddUIEventListener();
            transform.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// close view
    /// </summary>
    public virtual void Close(bool isForceClose = false)
    {
        if (transform.gameObject.activeSelf)
        {
            OnRemoveUIEventListener();
            OnDisable();

            if (!isForceClose)
            {
                // if this view game object in memory resident
                if (isPermanent)
                {
                    transform.gameObject.SetActive(false);
                }
                // else
                else
                {
                    GameObject.Destroy(transform.gameObject);
                    transform = null;
                }
            }
            else
            {
                GameObject.Destroy(transform.gameObject);
                transform = null;
            }
            isVisitable = false;
        }
    }

    /// <summary>
    /// preload view
    /// </summary>
    public virtual void PreLoad()
    {
        if(transform == null)
        {
            if (Create())
            {
                OnEnable();
            }
        }
    }

    /// <summary>
    /// flash view
    /// </summary>
    public virtual void Flash()
    {

    }

    public virtual Transform GetRoot()
    {
        return this.Transform;
    }

    #endregion

    #region Internal Use

    /// <summary>
    /// Create View
    /// </summary>
    /// <returns></returns>
    protected virtual bool Create()
    {
        // AssertName == null
        if (string.IsNullOrWhiteSpace(assertName))
        {
            Debug.LogWarning($"[{transform.gameObject.name}.{nameof(viewType)}.Create]: {AssertName} property is an empty");
            return false;
        }

        if (transform == null)
        {
            // find target view in Resources folder
            var view = Resources.Load<GameObject>(AssertName);

            // check it : if it is null, print error massage and throw exception
            if (transform == null)
            {
                Debug.LogError( $"[{transform.gameObject.name}.{nameof(viewType)}.Create]: Can not load view game object {AssertName}");
                throw new Exception();
            }

            // copy it to game space
            var viewInGameSpace = GameObject.Instantiate(view);
            transform = viewInGameSpace.transform;

            // hide it and set hide property
            transform.gameObject.SetActive(false);
            viewStateType = ViewStateType.Notice;
            UIRoot.SetParent(transform, viewStateType);
        }

        return true;
    }

    /// <summary>
    /// if you want set an view active-self is false, please use this function after set inactive
    /// </summary>
    protected virtual void SetViewHideProperty()
    {

    }

    protected virtual void SetViewEnableProperty()
    {

    }

    protected virtual void SetViewNoticeProperty()
    {

    }

    #endregion
}
