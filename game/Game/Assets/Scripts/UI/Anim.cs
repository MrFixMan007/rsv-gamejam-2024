using UnityEngine.EventSystems;
using UnityEngine;

public class Anim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("Active",true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("Active", false);
    }
}
