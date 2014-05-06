#region Class Information
/*----------------------------------------------------------------------------------
// File:           test.cs
// Project:          $projectName$
// Solution:           $solutionName$
// Description:        $description$
// Change History:
// Name				Date		Version		Description                    
// ----------------------------------------------------------------------------------
// Vincent Sai		$DATE$		1.0			Created
// ----------------------------------------------------------------------------------*/
# endregion
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Rand = UnityEngine.Random;
using Obj = UnityEngine.Object;
public class test : MonoBehaviour {

#region Variables
	float ratings = 1.0f;
	float policeScore = 0.0f;
	float studentScore = 0.0f;
	Rect policeButtonRect;
	Rect studentButtonRect;
	Rect ratingsRect;
	string ratingsContent;
	string policeContent;
	string studentContent;
	float countDownTime = 10f;
	bool gameOver = false;
	float coolDownTime = 0.0f;
#endregion

#region Methods
	void Awake()
	{
		policeButtonRect = new Rect(100, 100, 200, 100);
		studentButtonRect = new Rect(100, 300, 200, 100);
		ratingsRect = new Rect(100, 500, 200, 100);
	}
	// Use this for initialization
	void Start()
	{

	}
	// Update is called once per frame
	void Update()
	{
		ratingsContent = "收視率 : " + ratings.ToString();
		policeContent = "警察支持度 : " + policeScore.ToString();
		studentContent = "人民支持度 : " + studentScore.ToString();

		float balance = Mathf.Abs(policeScore - studentScore);
		if(balance > 5)
		{
			ratings += Rand.value * Time.deltaTime;
			if(balance > 10)
			{
				gameOver = true;
				enabled = false;
			}
			if(policeScore > studentScore)
			{
				policeScore += (Rand.value * 10 - 5) * Time.deltaTime;
				policeScore = Mathf.Max(policeScore, 0f);
			}
			else
			{
				studentScore += (Rand.value * 10 - 5) * Time.deltaTime;
				studentScore = Mathf.Max(studentScore, 0f);
			}
		}
		else
		{
			ratings -= Rand.value * Time.deltaTime;
			ratings = Mathf.Max(ratings, 0f);
		}

		if(ratings <= 0)
		{
			countDownTime -= Time.deltaTime;
			if(countDownTime <= 0)
			{
				gameOver = true;
				enabled = false;
			}
		}
		else
		{
			countDownTime = 10f;
//			policeScore += (Rand.value * 10 - 5) * Time.deltaTime;
//			studentScore += (Rand.value * 10 - 5) * Time.deltaTime;
//			policeScore = Mathf.Max(policeScore, 0f);
//			studentScore = Mathf.Max(studentScore, 0f);
		}
	}

	void OnGUI () {
		GUI.enabled = (coolDownTime <= 0);
		if(GUI.Button(policeButtonRect, policeContent))
		{
			policeScore += Rand.value * 5;
			StartCoroutine(CoolDown());
		}

		if(GUI.Button(studentButtonRect, studentContent))
		{
			studentScore += Rand.value * 5;
			StartCoroutine(CoolDown());
		}

		GUI.enabled = true;
		GUI.Label(ratingsRect, ratingsContent);
	}

	IEnumerator CoolDown () {
		coolDownTime = 3f;
		while(coolDownTime > 0)
		{
			coolDownTime -= Time.deltaTime;
			yield return null;
		}
	}
#endregion
}