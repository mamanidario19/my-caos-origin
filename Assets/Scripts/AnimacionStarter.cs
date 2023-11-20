using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionStarter : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doblarIzq()
    {
        animator.SetBool("Izq", true);
    }
    public void desdoblarIzq()
    {
        animator.SetBool("Izq", false);
    }

    public void doblarAb()
    {
        animator.SetBool("Ab", true);
    }
    public void dedoblarAb()
    {
        animator.SetBool("Ab", false);
    }
}
