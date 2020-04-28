using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.UI.ConsoleText
{
    public class GameTextManager : MonoBehaviour
    {
        private static GameTextManager _instance;

        [SerializeField] private float timeToTypeText;
        [SerializeField] private ConsoleTextEntry _template;

        private List<ConsoleTextEntry> _textEntries;
        private Queue<ConsoleTextEntry> _queuedTextEntries;

        private Coroutine _typewriterRoutine;

        // Start is called before the first frame update
        void Start()
        {
            if (_instance == null)
                _instance = this;
            else
                Debug.Log("Attempting to spawn separate instance of GameTextManager, aborting");
            _textEntries = new List<ConsoleTextEntry>();
            _queuedTextEntries = new Queue<ConsoleTextEntry>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_queuedTextEntries.Count > 0 && _typewriterRoutine == null)
            {
                _typewriterRoutine = StartCoroutine(Typewriter(_queuedTextEntries.Dequeue()));
            }
        }

        private IEnumerator Typewriter(ConsoleTextEntry queuedEntry)
        {
            string text = queuedEntry.Text.text;
            var timePerCharacter = timeToTypeText / text.Length;

            Queue<char> entryString = new Queue<char>();
            foreach (char t in text)
                entryString.Enqueue(t);

            text = "";
            queuedEntry.SetEntry(text, queuedEntry.TextColor);
            queuedEntry.gameObject.SetActive(true);
            while (entryString.Count > 0)
            {
                text += entryString.Dequeue();
                queuedEntry.SetEntry(text, queuedEntry.TextColor);
                yield return new WaitForSeconds(timePerCharacter);
            }

            _textEntries.Add(queuedEntry);
            _typewriterRoutine = null;
        }

        public void AddTextEntry(string text)
        {
            AddTextEntry(text, Color.white);
        }

        public void AddTextEntry(string text, Color color)
        {
            ConsoleTextEntry entryToQueue = Instantiate(_template, _template.transform.parent);
            entryToQueue.SetEntry(text, color);
            entryToQueue.gameObject.SetActive(false);
            _queuedTextEntries.Enqueue(entryToQueue);
        }
    }
}