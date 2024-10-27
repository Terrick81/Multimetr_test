using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SelectorLogic : MonoBehaviour
{
    private AudioSource _audioSource;
    private Animator _animator;
    private static UnityEvent<bool> IsHover = new UnityEvent<bool>();
    private static SelectorLogic Obj;

    public static void AddListener(UnityAction<bool> action)
    {
        IsHover.AddListener(action);
    }

    public static void RemoveListener(UnityAction<bool> action)
    {
        IsHover.RemoveListener(action);
    }
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        Obj = GetComponent<SelectorLogic>();
    }

    private void OnMouseEnter()
    {
        _animator.SetTrigger("IsHover");
        IsHover.Invoke(true);
    }
    private void OnMouseExit()
    {
        _animator.SetTrigger("Idle");
        IsHover.Invoke(false);
    }

    public static void SetRotationStatic(int state)
    {
        Obj.SetRotation(state);
    }

    private void SetRotation(int state)
    {
        Vector3 rotate = transform.eulerAngles;
        rotate.z = 90 + 360 * ((float)state / TesterControler.COUNT_OF_SELECTOR_POS);
        transform.rotation = Quaternion.Euler(rotate);
        _audioSource.PlayOneShot(_audioSource.clip);
    }

}
