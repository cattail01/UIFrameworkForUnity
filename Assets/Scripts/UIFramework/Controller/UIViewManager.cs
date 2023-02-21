
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI controller base class
/// </summary>
/// <remarks>
/// <para>we want to realize functions as follows: </para>
/// <para>* initialize (construct function) </para>
/// <para>* open, pre load or close view function</para>
/// <para>* find or hide all views by view type</para>
/// <para>notices: </para>
/// <para>* use base() in subclass's initial function (construct functions)</para>
/// </remarks>
public class UIViewManager: UnityStandardSingleton<UIViewManager>
{
    /// <summary>
    /// An dictionary records view type to view relations
    /// </summary>
    private Dictionary<ViewType, ViewBase> ViewTypeToViewDic;

    /// <summary>
    /// init view type to view dictionary
    /// </summary>
    private void InitializeViewTypeToViewDic()
    {
        // create view type to view dictionary
        ViewTypeToViewDic = new Dictionary<ViewType, ViewBase>();
        //todo  padding data (view type and view) into the dic

    }

    // initialize functions

    /// <summary>
    /// initial function
    /// </summary>
    public UIViewManager()
    {
        InitializeViewTypeToViewDic();
    }

    /// <summary>
    /// try to open view by view type
    /// </summary>
    /// <param name="viewType"></param>
    /// <returns>view which is opened</returns>
    public virtual ViewBase OpenView(ViewType viewType)
    {
        ViewBase view = null;
        if (ViewTypeToViewDic.TryGetValue(viewType, out view))
        {
            view.Open();
            return view;
        }
        else
        {
            Debug.LogError($"[{this.gameObject.name}.{nameof(UIViewManager)}.OpenView]: " +
                           $"Can not find view by view type {viewType}");
            return null;
        }
    }

    /// <summary>
    /// pre load view function
    /// </summary>
    /// <param name="type">scene type which view in</param>
    public virtual void PreLoadView(ScenesType type)
    {
        foreach (ViewBase view in ViewTypeToViewDic.Values)
        {
            if (view.ScenesType == type)
            {
                view.PreLoad();
            }
        }
    }

    /// <summary>
    /// close view function
    /// </summary>
    /// <param name="viewType"></param>
    /// <returns></returns>
    //public virtual ViewBase CloseView(ViewType viewType)
    public virtual void CloseView(ViewType viewType)
    {
        ViewBase view = null;
        if (ViewTypeToViewDic.TryGetValue(viewType, out view))
        {
            view.Close();
            //return view;
        }
        else
        {
            Debug.LogError($"[{this.gameObject.name}.{nameof(UIViewManager)}.CloseView]: " +
                           $"Can not find view by view type {viewType}");
            //return null;
        }
    }

    // hide all view by view type
    public virtual void HideAllView(ScenesType scenesType, bool isDestroy = false)
    {
        foreach (ViewBase view in ViewTypeToViewDic.Values)
        {
            if (view.ScenesType == scenesType)
            {
                view.Close(isDestroy);
            }
        }
    }

    // Force close all view
    public virtual void ForceCloseAllView(ScenesType scenesType)
    {
        foreach (ViewBase view in ViewTypeToViewDic.Values)
        {
            if (view.ScenesType == scenesType)
            {
                view.Close(true);
            }
        }
    }

    // get all views by view type


    // hide all views by view type


}
