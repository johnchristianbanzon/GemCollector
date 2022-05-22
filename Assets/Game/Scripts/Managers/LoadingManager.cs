
using System;

public class LoadingManager 
{
    private BlackLoadingView _blackLoadingView;

    public void SetView(BlackLoadingView blackLoadingView)
    {
        _blackLoadingView = blackLoadingView;
    }

    public void ShowLoading(Action onMidwayLoad)
    {
        _blackLoadingView.ShowLoading(onMidwayLoad);
    }
}