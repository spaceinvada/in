﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour {
    public bool dontDestroyOnWin;
	public event System.Action OnLose;
	public event System.Action OnWin;
    public float restartDelay = .1f;
    protected bool taskOver;
    protected bool inEasyMode_debug;
    protected int numRestarts;

    protected virtual void Update()
    {
        if (Application.isEditor && Input.GetKeyDown(KeyCode.Equals))
        {
            TaskCompleted();
        }
    }

    public virtual void SetNumRestarts(int i)
    {
        numRestarts = i;
    }

    protected virtual void TaskCompleted()
    {
        if (!taskOver)
        {
            taskOver = true;
            if (OnWin != null)
            {
                OnWin();
            }
        }
    }

	protected virtual void TaskFailed()
	{
        if (!taskOver)
        {
            taskOver = true;
            if (OnLose != null)
            {
                OnLose();
            }
        }
	}

    public virtual void EnterEasyMode_Debug()
    {
        inEasyMode_debug = true;
    }
}
