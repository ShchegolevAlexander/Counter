using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Text _text;

    private int _count;
    private WaitForSeconds _delay = new WaitForSeconds(0.5f);
    private Coroutine _coroutine;
    private bool _isCounting = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
            {
                StopCounter();
            }
            else
            {
                StartCounter();
            }
        }
    }

    private void StartCounter()
    {
        if (_coroutine == null)
        {
            _isCounting = true;
            _coroutine = StartCoroutine(UpdateCounter());
        }
    }

    private void StopCounter()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
            _isCounting = false;
        }
    }

    private IEnumerator UpdateCounter()
    {
        while (true)
        {
            yield return _delay;

            if (_text != null)
            {
                _count++;
                _text.text = _count.ToString();
            }
        }
    }
}
