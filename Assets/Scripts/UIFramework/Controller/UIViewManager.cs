
using System.Collections.Generic;

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
        
    }

    // open view function

    //
    public void OpenView()
    {

    }

    // pre load view function


    // close view function


    // get all views by view type


    // hide all views by view type


}
