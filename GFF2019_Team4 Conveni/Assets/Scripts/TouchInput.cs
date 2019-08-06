using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

    private static TouchInput _instance;
    private static TouchInput Instance
    {
        get
        {
            if(_instance == null)
            {
                var obj = new GameObject(typeof(TouchInput).Name);
                _instance = obj.AddComponent<TouchInput>();
            }
            return _instance;
        }
    }

    public static event System.Action<TouchInfo> Started
    {
        add
        {
            Instance._started += value;
        }
        remove
        {
            Instance._started -= value;
        }
    }

    public static event System.Action<TouchInfo> Moved{
        add
        {
            Instance._moved += value;
        }
        remove
        {
            Instance._moved -= value;
        }
    }

    public static event System.Action<TouchInfo> Ended
    {
        add
        {
            Instance._ended += value;
        }
        remove
        {
            Instance._ended -= value;
        }
    }

    private TouchInfo _info = new TouchInfo();
    private event System.Action<TouchInfo> _started;
    private event System.Action<TouchInfo> _moved;
    private event System.Action<TouchInfo> _ended;

    private TouchState State
    {
        get
        {
            if (Input.GetMouseButtonDown(0))
            {
                return TouchState.Started;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                return TouchState.Moved;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                return TouchState.Ended;
            }

            if(Input.touchCount > 0)
            {
                switch (Input.GetTouch(0).phase)
                {
                    case TouchPhase.Began:
                        return TouchState.Started;
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        return TouchState.Moved;
                    case TouchPhase.Canceled:
                    case TouchPhase.Ended:
                        return TouchState.Ended;
                    default:
                        break;
                }
            }
            return TouchState.None;
        }
    }

    //↓元はprivateだった
    public Vector2 Position
    {
        get
        {
            return State == TouchState.None ? Vector2.zero : (Vector2)Input.mousePosition;

            return Input.GetTouch(0).position;
        }
    }
    
	// Update is called once per frame
	private void Update () {
       if(State == TouchState.Started)
        {
            _info.screenPoint = Position;
            _info.deltaScreenPoint = Vector2.zero;
            if(_started != null)
            {
                _started(_info);
            }
        }
       else if(State == TouchState.Moved)
        {
            _info.deltaScreenPoint = Position - _info.screenPoint;
            _info.screenPoint = Position;
            if(_moved != null)
            {
                _moved(_info);
            }
        }
       else if(State == TouchState.Ended)
        {
            _info.deltaScreenPoint = Position - _info.screenPoint;
            _info.screenPoint = Position;
            if(_ended != null)
            {
                _ended(_info);
            }
        }
        else
        {
            _info.deltaScreenPoint = Vector2.zero;
            _info.screenPoint = Position;
            if(_ended != null)
            {
                _ended(_info);
            }
        }
	}
}

public class TouchInfo
{
    public Vector2 screenPoint;

    public Vector2 deltaScreenPoint;

    public Vector2 ViewportPoint
    {
        get
        {
            _viewportPoint.x = screenPoint.x / Screen.width;
            _viewportPoint.y = screenPoint.y / Screen.height;
            return _viewportPoint;
        }
    }

    public Vector2 DeltaViewportPoint
    {
        get
        {
            _deltaViewportPoint.x = deltaScreenPoint.x / Screen.width;
            _deltaViewportPoint.y = deltaScreenPoint.y / Screen.height;
            return _deltaViewportPoint;
        }
    }

    private Vector2 _viewportPoint = Vector2.zero;
    private Vector2 _deltaViewportPoint = Vector2.zero;
}

public enum TouchState
{
    //タッチなし
    None = 0,
    //タッチ開始
    Started = 1,
    //タッチ中
    Moved = 2,
    //タッチ終了
    Ended = 3,
}

//使い方
//TouchInput.Started += info => { /* 処理 */ };
