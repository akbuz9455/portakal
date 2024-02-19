using UnityEngine;
using DG.Tweening;
public class TouchController : MonoBehaviour
{
    public float laneDistance = 3f;
    public float laneChangeSpeed = 10f;
    public float jumpHeight = 2f;
    public float jumpDuration = 0.5f;

    public float swipeSensitivity = 50f; // Swipe hassasiyetini belirleyen değişken

    private Vector2 startTouchPosition, endTouchPosition;
    private int currentLane = 1;
    public bool isJumping = false;
    private float originalYPos;
    public AnimationManager animManager;
    public bool isFalling = false;
    void Start()
    {
        originalYPos = transform.localPosition.y;
        animManager = GetComponent<AnimationManager>();
    
    }

    void Update()
    {
        HandleSwipeInput();
    }

    private void HandleSwipeInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    endTouchPosition = touch.position;
                    ProcessSwipe();
                    break;
            }
        }
    }

    private void ProcessSwipe()
    {
        float swipeVertical = endTouchPosition.y - startTouchPosition.y;
        float swipeHorizontal = endTouchPosition.x - startTouchPosition.x;

        if (Mathf.Abs(swipeVertical) > Mathf.Abs(swipeHorizontal))
        {
            if (swipeVertical > swipeSensitivity && !isJumping && !isFalling) // Yukarı swipe hassasiyeti
            {
                Debug.Log("girdi yukarı zıpla");
                StartJump();
            }
            else if (swipeVertical < -swipeSensitivity && isJumping) // Aşağı swipe hassasiyeti
            {
                Debug.LogWarning("Girdi aşağı swing");
                // Zıplama tweenini durdur
                transform.DOKill();
                // Aşağı inme tweenini başlat
                isFalling = true;
                transform.DOLocalMoveY(originalYPos, jumpDuration / 8).SetEase(Ease.InQuad).OnComplete(() =>
                {
                    isFalling = false;
                    isJumping = false;
                    animManager.GoRun();
                });
            }
        }
        else
        {
            if (Mathf.Abs(swipeHorizontal) > swipeSensitivity) // Sağ/sol swipe hassasiyeti
            {
                MoveHorizontal(swipeHorizontal > 0);
            }
        }
    }


    private void StartJump()
    {
        isJumping = true;
        float jumpPeakY = originalYPos + jumpHeight;
        animManager.GoJump();
        transform.DOLocalMoveY(jumpPeakY, jumpDuration / 2).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            transform.DOLocalMoveY(originalYPos, jumpDuration / 2).SetEase(Ease.InQuad).OnComplete(() =>
            {
                isJumping = false;
                animManager.GoRun();
            });
        });
    }

    private void MoveHorizontal(bool goingRight)
    {
        int targetLane = currentLane + (goingRight ? 1 : -1);
        if (targetLane >= 0 && targetLane <= 2)
        {
            currentLane = targetLane;
            float targetX = (currentLane - 1) * laneDistance;
            transform.DOLocalMoveX(targetX, laneChangeSpeed).SetEase(Ease.OutQuad);
        }
    }
}
