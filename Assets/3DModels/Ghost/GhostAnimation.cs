using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimation : MonoBehaviour
{

    private Animator ghostAnimator;
    // Start is called before the first frame update
    void Start()
    {
        ghostAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
}
