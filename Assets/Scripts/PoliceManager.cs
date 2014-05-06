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
public class PoliceManager : MonoBehaviour {

#region Variables
	public int angry = 0;
	public int unite = 0;
	private ArrayList team = new ArrayList();
	private static PoliceManager _instance;
#endregion

#region Methods
	class PoliceManagerHelper {
		public PoliceManagerHelper () {
			_instance = (new GameObject(GameDefine.Strings.PoliceManager, typeof(PoliceManager))).GetComponent<PoliceManager>();
		}
	}

	public static PoliceManager instance {
		get
		{
			if( _instance == null )
				new PoliceManagerHelper();
			
			return _instance;
		}
	}

	void Awake () {
		_instance = this;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

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
			JoinTeam(new GameObject(GameDefine.Strings.Police));
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