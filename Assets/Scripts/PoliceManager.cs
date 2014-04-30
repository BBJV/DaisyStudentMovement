#region Class Information
/*----------------------------------------------------------------------------------
// File:           PoliceManager.cs
// Project:          DaisyStudentMovement
// Solution:           $solutionName$
// Description:        $description$
// Change History:
// Name				Date		Version		Description                    
// ----------------------------------------------------------------------------------
// Vincent Sai		2014/04/26		1.0			Created
// ----------------------------------------------------------------------------------*/
# endregion
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Rand = UnityEngine.Random;
using Obj = UnityEngine.Object;
public class PoliceManager {

#region Variables
	public int angry = 0;
	public int unite = 0;
	private ArrayList team = new ArrayList();
	private static PoliceManager _instance;
#endregion

#region Methods
	public PoliceManager () {
		if(_instance)
		{
			return _instance;
		}
		else
		{
			PoliceManager temp = Obj.FindObjectOfType(typeof(PoliceManager)) as PoliceManager;
			if(temp)
			{
				_instance = temp;
			}
			else
			{
				temp = (new GameObject(GameDefine.eString.PoliceManager, typeof(PoliceManager))).GetComponent<PoliceManager>();
				_instance = temp;
			}
			return _instance;
		}
	}
	void Awake()
	{

	}
	// Use this for initialization
	void Start()
	{

	}
	// Update is called once per frame
	void Update()
	{

	}
#endregion
}