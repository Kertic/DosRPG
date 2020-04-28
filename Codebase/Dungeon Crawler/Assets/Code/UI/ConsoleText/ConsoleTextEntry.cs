using TMPro;
using UnityEngine;

namespace Code.UI.ConsoleText
{
    public class ConsoleTextEntry : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        public TextMeshProUGUI Text
        {
            get { return _text; }
        }

        private Color _textColor = Color.white;

        public Color TextColor
        {
            get { return _textColor; }
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void SetEntry(string text)
        {
            _text.text = text;
        }

        public void SetEntry(string text, Color color)
        {
            _text.text = text;
            _text.color = color;
            _textColor = color;
        }
    }
}