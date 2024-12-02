using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    //textemesh du nombre de vie restant
    [SerializeField]
    private TextMeshProUGUI nbVie;
    //textmesh du nombre de point restant
    [SerializeField]
    private TextMeshProUGUI nbPoint;
    //textmesh qui affiche la round actuelle
    [SerializeField]
    private TextMeshProUGUI round;
    //textfield pour ajouter de l'argent
    [SerializeField]
    private TMP_InputField cheat;
    //bouton pour confirmer le montant d'argent qu'on veut ajouter
    [SerializeField]
    private Button cheatButton;
    //mixer group de la musique
    [SerializeField]
    private AudioMixerGroup musiqueMixerGroup;
    //mixer group des sound effects
    [SerializeField]
    private AudioMixerGroup soundEffectMixerGroup;
    //gameobject qui contient le Canvas du tuto
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

    /// <summary>
    /// ajoute le nombre de point écrit dans le textfield
    /// </summary>
    public void Cheats()
    {
        string pointString = cheat.text;
        if(float.TryParse(pointString, out float point_)) //source: https://stackoverflow.com/questions/15294878/how-the-int-tryparse-actually-works
        {
            MainController.ModifierPoint(point_);
        }
    }

    /// <summary>
    /// change le volume (ou le db) de la musique
    /// </summary>
    /// <param name="volume"></param>
    public void MusiqueVolume(float volume)
    {
        musiqueMixerGroup.audioMixer.SetFloat("musicVolume", volume); //source: https://docs.unity3d.com/ScriptReference/Audio.AudioMixer.SetFloat.html
    }

    /// <summary>
    /// change le volume (ou le db) du sound effect
    /// </summary>
    /// <param name="volume"></param>
    public void SoundEffectVolume(float volume)
    {
        soundEffectMixerGroup.audioMixer.SetFloat("effetVolume", volume);
    }

    /// <summary>
    /// ouvre le ui du tuto
    /// </summary>
    public void OpenTuto()
    {
        tutoHUD.SetActive(true);
    }

    /// <summary>
    /// ferme le ui du tuto
    /// </summary>
    public void CloseTuto()
    {
        tutoHUD.SetActive(false);
    }
}
