using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace MameshibaGames.Kekos.CharacterEditorScene.Customization
{
    public class CustomizationMediator : MonoBehaviour
    {
        [SerializeField] 
        private GameObject kekosCharacter;
        
     
      
        
        [Header("BODY MENU")]
        [SerializeField]
        private GameObject[] bodyMenus;

        [SerializeField]
        private PartCustomization torsoCustomization;
        
        [SerializeField]
        private PartCustomization legsCustomization;
        
        [SerializeField]
        private PartCustomization feetCustomization;
        
        [SerializeField]
        private PartCustomization handsCustomization;
        
        [SerializeField]
        private PartCustomization fullTorsoCustomization;
        
        [SerializeField]
        private PartCustomization torsoPropCustomization;

        [Header("HEAD AND SKIN MENU")]
        [SerializeField]
        private GameObject[] headMenus;

        [SerializeField]
        private PartCustomization hairCustomization;
        
        [SerializeField]
        private PartCustomization capCustomization;
        
        [SerializeField]
        private PartCustomization glassesCustomization;
        
        [SerializeField]
        private EyesCustomization eyesCustomization;

        [SerializeField]
        private SkinCustomization skinCustomization;

        [SerializeField]
        private PartCustomization eyebrowsCustomization;

        [SerializeField]
        private FaceCaracteristicsCustomization faceCaracteristicsCustomization;

        private const string _SaveString = "KEKOS_SavedCharacter";

        private void Awake()
        {
            kekosCharacter.SetActive(true);
            
            ChangeToBodyMenuIndex(0);

            // BODY
            fullTorsoCustomization.Init(kekosCharacter);
            torsoCustomization.Init(kekosCharacter);
            legsCustomization.Init(kekosCharacter);
            feetCustomization.Init(kekosCharacter);
            handsCustomization.Init(kekosCharacter);
            torsoPropCustomization.Init(kekosCharacter);
            
            // HEAD
            hairCustomization.Init(kekosCharacter);
            capCustomization.Init(kekosCharacter);
            glassesCustomization.Init(kekosCharacter);
            eyesCustomization.Init(kekosCharacter);
            skinCustomization.Init(kekosCharacter);
            eyebrowsCustomization.Init(kekosCharacter);
            faceCaracteristicsCustomization.Init(kekosCharacter);

           
          
        }

        private void OnEnable()
        {
            
        }

        public void LoadSettings()
        {
            string savedCharacterJson = PlayerPrefs.GetString("KEKOS_SavedCharacter", "");
            if (string.IsNullOrEmpty(savedCharacterJson)) return;

            SaveCustomizationModel saveCustomizationModel = JsonUtility.FromJson<SaveCustomizationModel>(savedCharacterJson);
            torsoCustomization.ChangeWithSaveItemInfo(saveCustomizationModel.torsoSelected);
            legsCustomization.ChangeWithSaveItemInfo(saveCustomizationModel.legsSelected);
            feetCustomization.ChangeWithSaveItemInfo(saveCustomizationModel.feetSelected);
            handsCustomization.ChangeWithSaveItemInfo(saveCustomizationModel.handsSelected);
            fullTorsoCustomization.ChangeWithSaveItemInfo(saveCustomizationModel.fullTorsoSelected);
            torsoPropCustomization.ChangeWithSaveItemInfo(saveCustomizationModel.torsoPropSelected);
            hairCustomization.ChangeWithSaveItemInfo(saveCustomizationModel.hairSelected);
            capCustomization.ChangeWithSaveItemInfo(saveCustomizationModel.capSelected);
            glassesCustomization.ChangeWithSaveItemInfo(saveCustomizationModel.glassesSelected);
            eyesCustomization.ChangeWithSaveItemInfo(saveCustomizationModel.eyesSelected);
            skinCustomization.ChangeWithSaveItemInfo(saveCustomizationModel.skinBaseSelected,
                saveCustomizationModel.skinDetailSelected);
            eyebrowsCustomization.ChangeWithSaveItemInfo(saveCustomizationModel.eyebrowsSelected);
            faceCaracteristicsCustomization.ChangeWithSaveItemInfo(saveCustomizationModel.faceCharacteristicsSelected);
        }

        public void SaveSettings()
        {
          
        }

        private void RandomizeAll()
        {
           
        }

        public void ChangeToBodyMenuIndex(int index)
        {
            foreach (GameObject bodyMenu in bodyMenus)
                bodyMenu.SetActive(false);
            
            bodyMenus[index].SetActive(true);
        }
        
        public void ChangeToHeadMenuIndex(int index)
        {
            foreach (GameObject headMenu in headMenus)
                headMenu.SetActive(false);
            
            headMenus[index].SetActive(true);
        }

        private void OnDestroy()
        {
            skinCustomization.Clean();
            eyesCustomization.Clean();
        }
    }
}
