using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OSVR.Unity;


    public class interactable : MonoBehaviour
    {
        [System.Serializable]
        public class Action
        {
            public Color color;
            public Sprite sprite;
            public string title;
        }

        [SerializeField]
        public Action[] options = new Action[3];

        void Start()
        {
        }

        void OnMouseDown()
        {

            if (this.name != "Terrain")
            {
                Debug.Log(this.name);
                ObjectMenus();
                RadialMenuSpawner.ins.SpawnMenu(this);
            }
            else
            {
                Debug.Log(this.name);
            }


        }
        void ObjectMenus()
        {
            Sprite[] images = { Resources.Load<Sprite>("moveIcon"), Resources.Load<Sprite>("deleteIcon"), Resources.Load<Sprite>("deleteIcon") };

            Vector4[] colors = { new Vector4(1.0f, 0.0f, 0.0f, 1.0f), new Vector4(.279f, .344f, 1.00f, 1.00f), new Vector4(.990f, 1.00f, .279f, 1.00f) };
            string[] title = { "Move", "Delete", "random" };

            for (int i = 0; i < 3; i++)
            {
                options[i].color = colors[i];
                options[i].sprite = images[i];
                options[i].title = title[i];
            }
        }
        void TerrainMenu()
        {
            Sprite[] images = { Resources.Load<Sprite>("moveIcon"), Resources.Load<Sprite>("deleteIcon"), Resources.Load<Sprite>("deleteIcon") };

            Vector4[] colors = { new Vector4(1.0f, 0.0f, 0.0f, 1.0f), new Vector4(.279f, .344f, 1.00f, 1.00f), new Vector4(.990f, 1.00f, .279f, 1.00f) };
            string[] title = { "Move", "Delete", "random" };


        }
    }
