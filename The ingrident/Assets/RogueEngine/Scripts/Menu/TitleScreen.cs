using System.Collections;
using RogueEngine;
using RogueEngine.Client;
using RogueEngine.UI;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

namespace RogueEngine.UI
{
    public class TitleScreen : MonoBehaviour
    {
        //TitleScreen script
        public AudioClip music;
        public AudioClip ambience;

        [Header("UI")]
        public Text version_text;
        private bool starting = false;

        public static TitleScreen instance;
        void Awake()
        {
            instance = this;
            Application.targetFrameRate = 120;
            GameClient.connect_settings = ConnectSettings.Default;
            World.Unload();
        }
        private void Start()
        {
            BlackPanel.Get().Show();
            AudioTool.Get().PlayMusic("music", music);
            AudioTool.Get().PlaySFX("ambience", ambience, 0.5f, true, true);

            version_text.text = "Version " + Application.version;

        }
        private async void RefreshLog()
        {
            bool success = await Authenticator.Get().RefreshLogin();
            if (success)
                AfterLog();
            else
                SceneNav.GoToLoginMenu();

        }
        private void AfterLog()
        {
            BlackPanel.Get().Hide();
            RefreshUse();

        }
        public async void RefreshUse()
        {
            await Authenticator.Get().LoadUserData();

            UserData udata = Authenticator.Get().GetUserData();
            if (udata != null)
                return;

        }
        public void CreateGame(GameType type)
        {
            string user_id = Authenticator.Get().UserID;
            string file = user_id + "_" + (type == GameType.MultiHost ? "lan" : "solo");
            CreateGame(type, file, GameTool.GenerateRandomID());
        }

        public void CreateGame(GameType type, string filename, string game_uid)
        {
            GameClient.connect_settings.game_type = type;
            GameClient.connect_settings.file_host = true;
            GameClient.connect_settings.load = false;
            GameClient.connect_settings.server_url = "";
            GameClient.connect_settings.game_uid = game_uid;
            GameClient.connect_settings.filename = filename;
            StartGame();
        }
        public void LoadGame(GameType type, string filename)
        {
            string user_id = Authenticator.Get().UserID;
            World game = World.Load(filename);
            if (game != null && game.GetPlayer(user_id) != null)
            {
                GameClient.connect_settings.game_type = type;
                GameClient.connect_settings.file_host = true;
                GameClient.connect_settings.load = true;
                GameClient.connect_settings.server_url = "";
                GameClient.connect_settings.game_uid = game.game_uid;
                GameClient.connect_settings.filename = filename;

                StartGame();
            }
        }
        public void JoinGame(GameType type, string game_uid, string server_url)
        {
            GameClient.connect_settings.game_type = type;
            GameClient.connect_settings.file_host = false;
            GameClient.connect_settings.load = false;
            GameClient.connect_settings.server_url = server_url; //If Empty server_url, will use the default one in NetworkData
            GameClient.connect_settings.game_uid = game_uid;
            GameClient.connect_settings.filename = "";
            StartGame();
        }

        public void StartGame()
        {
            if (!starting)
            {
                starting = true;
                LobbyClient.Get().Disconnect();
                StartCoroutine(FadeToGame());
            }
        }
        public void OnClickSoloNew()
        {
            CreateGame(GameType.Solo);
        }

        public void OnClickSoloLoad()
        {
            string user_id = Authenticator.Get().UserID;
            LoadGame(GameType.Solo, World.GetLastSave(user_id));
        }
        public void OnClickSettings()
        {
            SettingsPanel.Get().Show();
        }
        private IEnumerator FadeToGame()
        {
            BlackPanel.Get().Show();
            AudioTool.Get().FadeOutMusic("music");
            yield return new WaitForSeconds(1f);
            SceneNav.GoToSetup();
        }
        private IEnumerator FadeLogout()
        {
            BlackPanel.Get().Show();
            AudioTool.Get().FadeOutMusic("music");
            yield return new WaitForSeconds(1f);
            SceneNav.GoToLoginMenu();
        }

        public void OnClickQuit()
        {
            Application.Quit();
        }

        public static TitleScreen Get()
        {
            return instance;
        }

    }
}
