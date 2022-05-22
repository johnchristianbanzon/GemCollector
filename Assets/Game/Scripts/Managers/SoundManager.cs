public class SoundManager 
{
    private const string GameBgm = "Game-BGM";
    private const string MenuBgm = "Game-Menu";
    private SoundView _soundView;


    public void SetView(SoundView soundView)
    {
        _soundView = soundView;
    }

    public void PlayGameBGM()
    {
        _soundView.PlayBgm(GameBgm);
    }

    public void PlayMenuBGM()
    {
        _soundView.PlayBgm(MenuBgm);
    }

    public void PlaySFX(string sfxName)
    {
        _soundView.PlaySFX(sfxName);
    }
}