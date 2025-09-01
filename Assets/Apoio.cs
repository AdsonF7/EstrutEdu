using EstrutEdu;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace EstrutEdu {
    public enum TipoApoio
    {
        ENGASTADO,
        LIVRE,
        APOIADO,
    };

    public enum LocalApoio
    {
        TOPO,
        BASE
    }

    public class Apoio : MonoBehaviour
    {
        public Camera cam;
        public GameObject dd_TipoApoios;
        public RectTransform canvasTransform;
        //public TipoApoio TipoApoio;
        //public GameObject go_Apoiado { get; private set; }
        //public GameObject go_Engastado { get; private set; }
        //public Apoio(TipoApoio tipoApoio, LocalApoio localApoio, Vector3 comprimento)
        //{
        //    go_Apoiado = GameObject.Find("go_Apoiado");
        //    go_Engastado = GameObject.Find("go_Engastado");
        //}

        //public void mudarApoio(TipoApoio tipoApoio)
        //{
        //    if (tipoApoio == TipoApoio.ENGASTADO)
        //    {
        //        Instantiate(go_Engastado);
        //    }
        //    else if (tipoApoio == TipoApoio.APOIADO)
        //    {
        //        Instantiate(go_Apoiado);
        //    }
        //    TipoApoio = tipoApoio;
        //}
        public TipoApoio TipoApoio { get; set; }

        void Update()
        {
            if (Input.GetMouseButtonDown(0)) // clique esquerdo
            {
                // Verifica se clicou em UI
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    GameObject clickedUI = EventSystem.current.currentSelectedGameObject;

                    if (clickedUI == null || !clickedUI.transform.IsChildOf(dd_TipoApoios.transform))
                    {
                        HideMenu(); // fechamos só se NÃO for parte do dropdown
                    }
                    return;
                }

                // Se não clicou na UI → faz Raycast no mundo
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Clicavel"))
                    {
                        ShowMenuAtMouse();
                    }
                    else
                    {
                        HideMenu();
                    }
                }
                else
                {
                    HideMenu();
                }
            }
        }

        void ShowMenuAtMouse()
        {
            dd_TipoApoios.SetActive(true);

            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasTransform,
                Input.mousePosition,
                null, // se o Canvas for ScreenSpace-Overlay
                out pos
            );

            dd_TipoApoios.GetComponent<RectTransform>().anchoredPosition = pos;
        }

        void OnObjectClicked()
        {
            Debug.Log("Objeto clicado: " + this.name);
        }

        public void HideMenu()
        {
            dd_TipoApoios.SetActive(false);
        }
    }
}
