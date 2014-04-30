#region Class Information
/*----------------------------------------------------------------------------------
// File:           StudentManager.cs
// Project:          DaisyStudentMovement
// Solution:           $solutionName$
// Description:        $description$
//
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
public class StudentManager {

#region Variables
	public int angry = 0;
	public int unite = 0;
	private ArrayList team = new ArrayList();
	private static StudentManager _instance;
#endregion

#region Methods
	public StudentManager () {
		if(_instance)
		{
			return _instance;
		}
		else
		{
			StudentManager temp = Obj.FindObjectOfType(typeof(StudentManager)) as StudentManager;
			if(temp)
			{
				_instance = temp;
			}
			else
			{
				temp = (new GameObject(GameDefine.eString.StudentManger, typeof(StudentManager))).GetComponent<StudentManager>();
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

	public void JoinTeam (GameObject obj) {
		if(!team.Contains(obj))
		{
			team.Add(obj);
		}
	}

	public void JoinTeam (int num) {
		for(int i = 0; i < num; i++)
		{
			JoinTeam(new GameObject(GameDefine.eString.Student));
		}
	}

	public void ExitTeam (GameObject obj) {
		if(team.Contains(obj))
		{
			team.Remove(obj);
			Obj.Destroy(obj);
		}
	}

#endregion
}