using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
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
    public bool start;
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
            
            if (!start)
            {
                start = true;
                InGameManager.Instance.startGame();
            }
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
                animManager.GoFlip();

                transform.DOLocalMoveY(originalYPos, jumpDuration / 6).SetEase(Ease.InQuad).OnComplete(() =>
                {
                    isFalling = false;
                    isJumping = false;

                    animManager.GoRun();
                });
            }

            if (swipeVertical < swipeSensitivity && !isJumping && !isFalling) // Yukarı swipe hassasiyeti
            {
                Debug.Log("girdi yukarı zıpla");
                animManager.GoFlip();
                Invoke("GoRunDelay",0.1f);

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

    public void GoRunDelay()
    {
        animManager.GoRun();

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

            // Aracın yatay hareketi
            transform.DOLocalMoveX(targetX, laneChangeSpeed).SetEase(Ease.OutQuad);

            // Aracın dönüş animasyonu
            float tiltAngle = 15; // Dönüş açısını ayarlayabilirsiniz.
            Quaternion targetRotation = Quaternion.Euler(0, goingRight ? tiltAngle : -tiltAngle, 0);
            transform.GetChild(0).DOLocalRotateQuaternion(targetRotation, laneChangeSpeed / 2).SetEase(Ease.OutBack);

            // Aracın orijinal rotasyonuna dönmesi
            Quaternion originalRotation = Quaternion.Euler(0, 0, 0);
            transform.GetChild(0).DOLocalRotateQuaternion(originalRotation, laneChangeSpeed / 2).SetEase(Ease.InBack).SetDelay(laneChangeSpeed / 2);
        }
    }
}
