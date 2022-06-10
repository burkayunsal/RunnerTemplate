using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    private PathCreation.Examples.PathFollower pathFollower;

    private Animator animator;

    [Header("Movement Settings")]
    public float xSpeed;
    private Touch touch;

    [Header("Collision Settings")]
    public int point;

    private bool gameFail;

    public Transform arrow;

    private void Awake() {
        instance = this;
    }
    void Start()
    {
        animator = transform.GetComponent<Animator>();

        pathFollower = transform.parent.GetComponent<PathCreation.Examples.PathFollower>();

        FindObjectOfType<Cinemachine.CinemachineVirtualCamera>().Follow = transform.parent;
        FindObjectOfType<Cinemachine.CinemachineVirtualCamera>().LookAt = transform.parent;
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if(gameFail) {
            return;
        }
        
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {

                if (CanvasManager.instance.guide.activeInHierarchy)
                {
                    MoveForward();

                    CanvasManager.instance.guide.SetActive(false);
                }
                
                var pos = transform.localPosition;

                transform.localPosition = new Vector3(Mathf.Clamp(pos.x + touch.deltaPosition.x * xSpeed * Time.deltaTime, -3.0f, 3.0f), 0, pos.z);
            }
        }
        
    }

    public void MoveForward() {
        pathFollower.enabled = true;

        animator.SetBool("EnableRun", true);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Obstacle")) {
            Destroy(other.transform.parent.gameObject);
            point--;
            if(point < 0) {
                pathFollower.enabled = false;
                FailPanel.instance.OpenPanel();
                gameFail = true;
                animator.SetBool("EnableRun", false);
            }
            CanvasManager.instance.SetCounterText(point);
        }

        if(other.CompareTag("Diamond")) {
            Destroy(other.gameObject);
            point++;
            CanvasManager.instance.SetCounterText(point);
        }

        if(other.CompareTag("Finish")) {
           other.enabled = false;
           pathFollower.enabled = false;
           animator.SetBool("EnableRun", false);
           Camera.main.GetComponent<Cinemachine.CinemachineBrain>().enabled = false;
           Camera.main.transform.parent = arrow;
           IncreaseArrow(0); 
        } 
    }

   public void IncreaseArrow(int que)
    {
        if(point > 0)
        {
            point--;
            var i=que;
            arrow.DOMoveY(Level.instance.endCubes[i].position.y,0.25f).OnComplete(()=>{
            i++;
            IncreaseArrow(i);
        });
        }
        else {
            CompletePanel.instance.OpenPanel();
        
        }
    }
    
}
