
using System.Collections.Generic;
using System.Linq;
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
    /// is UI view visitable
    /// </summary>
    protected bool isVisitable = false;

    /// <summary>
    /// view type
    /// </summary>
    protected ViewType viewType;

    /// <summary>
    /// scene type
    /// </summary>
    protected ScenesType scenesType;

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
}
