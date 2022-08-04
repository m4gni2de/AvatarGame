using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMotion : MonoBehaviour
{
    public GameObject worldCanvas;
    public bool isClicked;

    public float cameraMoveSpeed;
    private Vector2 facingDirection;
    private float xDiff, yDiff, acumTime;

    public Vector3 clickPosition;

    public Camera mainCamera;
    public float maxCameraSize, minCameraSize;
    public Vector2 minPos, maxPos;
    public float minSizePercent = .6f;

    public bool focusOnAct = true;
    public float focusTime = 2f;
    // Start is called before the first frame update

    //bool that other scripts can manipulate to turn off/on the ability to move the camera
    public bool isFree = true;

    public float width;
    public float height;
    public float sizeDiff;


    public GameObject followObject;

    public bool isFocus = false;

    public float lastOrtho;
    public Vector3 lastCamPos;

    public Vector2?[] oldTouchPositions = {
        null,
        null
    };
    Vector2 oldTouchVector;
    float oldTouchDistance;

    private bool isShaking = false;
    // Start is called before the first frame update
    void Start()
    {
        //BattleEvents.current.OnAttackSelect += AttackSelectWatcher;
        //BattleEvents.current.OnAttackUse += AttackUseWatcher;
        //BattleEvents.current.OnMonsterSelect += MonsterSelectWatcher;
        //BattleEvents.current.OnMonsterTurnStart += TurnStartWatcher;
        //BattleEvents.current.OnBattleEnd += BattleEndWatcher;
        //BattleEvents.current.OnAttackHit += AttackHitWatcher;
        width = worldCanvas.GetComponent<RectTransform>().rect.width;
        height = worldCanvas.GetComponent<RectTransform>().rect.height;
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = width / height;



        if (screenRatio >= targetRatio)
        {
            //Camera.main.orthographicSize = height / 2;
            mainCamera.orthographicSize = (height / 2) * worldCanvas.transform.localScale.y;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            mainCamera.orthographicSize = height / 2 * differenceInSize;
        }

        //mainCamera.orthographicSize *= GameManager.Instance.settingsManager.gameSettings.screenRatio;
        maxCameraSize = mainCamera.orthographicSize;
        minCameraSize = maxCameraSize * minSizePercent;

    }

    //private void AttackHitWatcher(GameObject arg1, AttackDamage arg2)
    //{
    //    if (!isShaking)
    //    {
    //        CameraShake();
    //    }
    //}

    //private void BattleEndWatcher()
    //{
    //    //GameEvents.current.OnAttackSelect -= AttackSelectWatcher;
    //    BattleEvents.current.OnAttackSelect -= AttackSelectWatcher;
    //    //GameEvents.current.OnAttackUse -= AttackUseWatcher;
    //    BattleEvents.current.OnAttackUse -= AttackUseWatcher;
    //    //GameEvents.current.OnMonsterSelect -= MonsterSelectWatcher;
    //    BattleEvents.current.OnMonsterSelect -= MonsterSelectWatcher;
    //    //GameEvents.current.OnMonsterTurnStart -= TurnStartWatcher;
    //    BattleEvents.current.OnMonsterTurnStart -= TurnStartWatcher;
    //    //GameEvents.current.OnAttackHit -= AttackHitWatcher;
    //    BattleEvents.current.OnAttackHit -= AttackHitWatcher;
    //    //GameEvents.current.OnBattleEnd -= BattleEndWatcher;
    //    BattleEvents.current.OnBattleEnd -= BattleEndWatcher;

    //}

    //private void AttackUseWatcher(Attack arg1, MonsterSpawn arg2, List<GameObject> arg3)
    //{
    //    oldTouchPositions[0] = null;
    //    oldTouchPositions[1] = null;
    //    isClicked = false;
    //    acumTime = 0;
    //    ToggleFree(true);



    //    if (GameManager.Instance.settingsManager.gameSettings.FocusOnActingMonster)
    //    {
    //        StopAllCoroutines();
    //        isFocus = false;

    //        //mainCamera.orthographicSize = lastOrtho;
    //        //mainCamera.transform.position = lastCamPos;
    //        StartCoroutine(FocusOnMonster(arg2.gameObject));
    //    }

    //}

    //private void TurnStartWatcher(MonsterSpawn obj)
    //{
    //    oldTouchPositions[0] = null;
    //    oldTouchPositions[1] = null;
    //    isClicked = false;
    //    acumTime = 0;
    //    ToggleFree(true);
    //}

    //private void MonsterSelectWatcher(GameObject obj)
    //{
    //    oldTouchPositions[0] = null;
    //    oldTouchPositions[1] = null;
    //    isClicked = false;
    //    acumTime = 0;
    //    ToggleFree(true);
    //}

    //private void AttackSelectWatcher(Attack obj)
    //{
    //    oldTouchPositions[0] = null;
    //    oldTouchPositions[1] = null;
    //    isClicked = false;
    //    acumTime = 0;
    //    ToggleFree(false);
    //}

    //private IEnumerator FocusOnMonster(GameObject obj)
    //{
    //    lastOrtho = mainCamera.orthographicSize;
    //    lastCamPos = mainCamera.transform.position;


    //    isFocus = true;
    //    float acumTime = 0;
    //    do
    //    {
    //        Vector3 diff = obj.transform.position - transform.position;
    //        mainCamera.orthographicSize -= (1 * cameraMoveSpeed);
    //        mainCamera.transform.Translate(diff, Space.Self);
    //        yield return new WaitForEndOfFrame();
    //        acumTime += Time.deltaTime;
    //    } while (acumTime < focusTime || mainCamera.orthographicSize > minCameraSize);

    //    yield return new WaitUntil(() => acumTime >= focusTime || mainCamera.orthographicSize <= minCameraSize);
    //    mainCamera.orthographicSize = lastOrtho;
    //    mainCamera.transform.position = lastCamPos;
    //    isFocus = false;
    //}

    // Update is called once per frame
    void Update()
    {
        //float width = worldCanvas.GetComponent<RectTransform>().rect.width;
        //float height = worldCanvas.GetComponent<RectTransform>().rect.height;
        //float screenRatio = (float)Screen.width / (float)Screen.height;
        //float targetRatio = width / height;



        //if (screenRatio >= targetRatio)
        //{
        //    //Camera.main.orthographicSize = height / 2;
        //    Camera.main.orthographicSize = (height /2) * worldCanvas.transform.localScale.y;
        //}
        //else
        //{
        //    float differenceInSize = targetRatio / screenRatio;
        //    Camera.main.orthographicSize = height / 2 * differenceInSize;
        //}
        if (isFree)
        {

#if UNITY_EDITOR
            MouseCamera();
#else
        TouchCamera();
#endif
            if (mainCamera.orthographicSize >= maxCameraSize)
            {
                mainCamera.orthographicSize = maxCameraSize;
            }

            if (mainCamera.orthographicSize <= minCameraSize)
            {
                mainCamera.orthographicSize = minCameraSize;
            }

            sizeDiff = 1 - (mainCamera.orthographicSize / maxCameraSize);

            minPos = new Vector2(-width * sizeDiff / 2, -height * sizeDiff / 2);
            maxPos = new Vector2(width * sizeDiff / 2, height * sizeDiff / 2);

        }
    }


    public void LateUpdate()
    {
        if (!isShaking)
        {


            if (!isFocus)
            {
                if (mainCamera.transform.localPosition.x > maxPos.x)
                {
                    mainCamera.transform.localPosition = new Vector2(maxPos.x, mainCamera.transform.localPosition.y);
                }
                if (mainCamera.transform.localPosition.x < minPos.x)
                {
                    mainCamera.transform.localPosition = new Vector2(minPos.x, mainCamera.transform.localPosition.y);
                }

                if (mainCamera.transform.localPosition.y > maxPos.y)
                {
                    mainCamera.transform.localPosition = new Vector2(mainCamera.transform.localPosition.x, maxPos.y);
                }
                if (mainCamera.transform.localPosition.y < minPos.y)
                {
                    mainCamera.transform.localPosition = new Vector2(mainCamera.transform.localPosition.x, minPos.y);
                }
            }

            mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, -40f);
        }

        //GameManager.Instance.CameraMove();
    }

    public void MouseCamera()
    {
        var worldMousePosition =
                    Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        var x = worldMousePosition.x;
        var y = worldMousePosition.y;
        if (Input.GetMouseButton(0))
        {
            if (isClicked == false)
            {
                isClicked = true;
                clickPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            }
            if (isClicked)
            {
                //Debug.Log(worldMousePosition);

                if (worldMousePosition != clickPosition)
                {
                    facingDirection = clickPosition - worldMousePosition;

                    xDiff = clickPosition.x - worldMousePosition.x;
                    yDiff = clickPosition.y - worldMousePosition.y;

                    if (facingDirection.x != 0) { mainCamera.transform.Translate(new Vector3(xDiff / cameraMoveSpeed, 0), Space.Self); }
                    if (facingDirection.y != 0) { mainCamera.transform.Translate(new Vector3(0, yDiff) / cameraMoveSpeed, Space.Self); }

                }
            }

        }
        else
        {

            if (isClicked == true)
            {
                acumTime += 3;
                mainCamera.transform.Translate(facingDirection / (cameraMoveSpeed + acumTime), Space.Self);

                if (acumTime >= 21 || Input.GetMouseButton(0))
                {
                    mainCamera.transform.position = mainCamera.transform.position;
                    isClicked = false;
                    acumTime = 0;
                }
            }
            //isClicked = false;
        }



        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            mainCamera.orthographicSize += (1 * cameraMoveSpeed);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            mainCamera.orthographicSize -= (1 * cameraMoveSpeed);
        }

        //if (mainCamera.orthographicSize >= maxCameraSize)
        //{
        //    mainCamera.orthographicSize = maxCameraSize;
        //}


    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void TouchCamera()
    {
        if (Input.touchCount == 0 || IsPointerOverUIObject())
        {
            oldTouchPositions[0] = null;
            oldTouchPositions[1] = null;
            ToggleFree(true);

        }
        else if (Input.touchCount == 1 && !IsPointerOverUIObject())
        {



            if (oldTouchPositions[0] == null || oldTouchPositions[1] != null)
            {
                oldTouchPositions[0] = Input.GetTouch(0).position;
                oldTouchPositions[1] = null;
            }
            else
            {
                Vector2 newTouchPosition = Input.GetTouch(0).position;

                mainCamera.transform.position += mainCamera.transform.TransformDirection((Vector3)((oldTouchPositions[0] - newTouchPosition) * mainCamera.orthographicSize / mainCamera.pixelHeight * 2f));

                oldTouchPositions[0] = newTouchPosition;
            }
        }
        else
        {
            if (!!IsPointerOverUIObject())
            {
                if (oldTouchPositions[1] == null)
                {
                    oldTouchPositions[0] = Input.GetTouch(0).position;
                    oldTouchPositions[1] = Input.GetTouch(1).position;
                    oldTouchVector = (Vector2)(oldTouchPositions[0] - oldTouchPositions[1]);
                    oldTouchDistance = oldTouchVector.magnitude;
                }
                else
                {
                    Vector2 screen = new Vector2(mainCamera.pixelWidth, mainCamera.pixelHeight);

                    Vector2[] newTouchPositions = {
                    Input.GetTouch(0).position,
                    Input.GetTouch(1).position
                };
                    Vector2 newTouchVector = newTouchPositions[0] - newTouchPositions[1];
                    float newTouchDistance = newTouchVector.magnitude;

                    mainCamera.transform.position += mainCamera.transform.TransformDirection((Vector3)((oldTouchPositions[0] + oldTouchPositions[1] - screen) * mainCamera.orthographicSize / screen.y));
                    //transform.localRotation *= Quaternion.Euler(new Vector3(0, 0, Mathf.Asin(Mathf.Clamp((oldTouchVector.y * newTouchVector.x - oldTouchVector.x * newTouchVector.y) / oldTouchDistance / newTouchDistance, -1f, 1f)) / 0.0174532924f));
                    mainCamera.orthographicSize *= oldTouchDistance / newTouchDistance;
                    mainCamera.transform.position -= mainCamera.transform.TransformDirection((newTouchPositions[0] + newTouchPositions[1] - screen) * mainCamera.orthographicSize / screen.y);

                    oldTouchPositions[0] = newTouchPositions[0];
                    oldTouchPositions[1] = newTouchPositions[1];
                    oldTouchVector = newTouchVector;
                    oldTouchDistance = newTouchDistance;
                }
            }

        }





        //for (var i = 0; i < Input.touchCount; ++i)
        //{

        //    Input.GetTouch(0).
        //}
    }

    public void ToggleFree(bool free)
    {
        isFree = free;
    }

    private void CameraShake()
    {

        Vector3 orgPos = mainCamera.transform.position;
        float shakeAmt = 2f;
        StartCoroutine(Shake(orgPos, shakeAmt));
    }

    private IEnumerator Shake(Vector3 org, float shakeAmt)
    {
        if (shakeAmt > 0)
        {
            float acumTime = 0f;
            do
            {
                isShaking = true;
                float quakeAmt = UnityEngine.Random.value * shakeAmt * 2 - shakeAmt;
                Vector3 pp = mainCamera.transform.position;
                pp.y += quakeAmt; // can also add to x and/or z
                pp.x -= quakeAmt;
                mainCamera.transform.position = pp;

                acumTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            } while (acumTime < 1f);

            mainCamera.transform.position = org;
            isShaking = false;
        }
    }
}


