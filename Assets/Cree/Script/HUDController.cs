using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nbVie;
    [SerializeField]
    private TextMeshProUGUI nbPoint;
    [SerializeField]
    private TextMeshProUGUI round;
    [SerializeField]
    private TMP_InputField cheat;
    [SerializeField]
    private Button cheatButton;
    [SerializeField]
    private AudioMixerGroup musiqueMixerGroup;
    [SerializeField]
    private AudioMixerGroup soundEffectMixerGroup;
    [SerializeField]
    private GameObject tutoHUD;

    void Start()
    {
        tutoHUD.SetActive(false);
    }

    void Update()
    {
        nbVie.SetText($"{MainController.vie}");
        nbPoint.SetText($"{MainController.points}$");
        round.SetText($"{MainController.manche}");
    }

    public void Cheats()
    {
        string pointString = cheat.text;
        if(float.TryParse(pointString, out float point_)) //source: https://stackoverflow.com/questions/15294878/how-the-int-tryparse-actually-works
        {
            MainController.ModifierPoint(point_);
        }
    }

    public void MusiqueVolume(float volume)
    {
        musiqueMixerGroup.audioMixer.SetFloat("musicVolume", volume); //source: https://docs.unity3d.com/ScriptReference/Audio.AudioMixer.SetFloat.html
    }

    public void SoundEffectVolume(float volume)
    {
        soundEffectMixerGroup.audioMixer.SetFloat("effetVolume", volume);
    }

    public void OpenTuto()
    {
        tutoHUD.SetActive(true);
    }

    public void CloseTuto()
    {
        tutoHUD.SetActive(false);
    }
}
