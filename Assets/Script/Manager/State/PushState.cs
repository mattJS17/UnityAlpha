﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushState : GameState {

	private GameManager gameManager;
	private List<GameObject> listMonster;

	GameObject monster;

	public float speed = 1f;

	public override void Init(GameManager gameManager){
		this.gameManager = gameManager;
		listMonster = gameManager.getListMonster ();
	}

	public override void Restart(){
		Time.timeScale = 5f;
		//print ("Move Start");
		for (int i = 0; i < listMonster.Count; i++) {
			listMonster [i].GetComponent<Monster> ().Move ();
		}
	}

	public override void Update () {
		
		if (listMonster.Count == 0)
			gameManager.ChangeState ((int)State.Data.EndState);
	

		if (!gameManager.GetRunning()) {  
			Time.timeScale = 1f;
			gameManager.ChangeState ((int)State.Data.AttackState);
		}


	}

	public override void Inputkey(char key){
		
	}
}
