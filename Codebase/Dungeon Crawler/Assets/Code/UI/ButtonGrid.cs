using UnityEngine;

namespace Code.UI
{
    public class ButtonGrid: MonoBehaviour
    {
        #pragma warning disable CS0649
        [SerializeField]
        private GameObject _templateButton;
        #pragma warning restore CS0649

        private GameObject[] _buttons;
        // Start is called before the first frame update
        void Start()
        {
            CreateButtonArray(10);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void CreateButtonArray( /*skills would go here*/ int count)
        {
            _buttons = new GameObject[count];
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i] = Instantiate(_templateButton, _templateButton.transform.parent);
                _buttons[i].SetActive(true);
            }
        }
    }
}
