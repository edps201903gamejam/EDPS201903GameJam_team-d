using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	private float timer;
	private int mazaiSum;
	private int CurrentAnimalNum;
	[SerializeField] private GameObject[] animalUI = new GameObject[5];
	[SerializeField] private GameObject[] animalIcon = new GameObject[5]; //0は人なので使用しない
	[SerializeField] private GameObject animalMode;
	[SerializeField] private Sprite[] animalIconNone = new Sprite[5]; //0は人なので使用しない
	[SerializeField] private Sprite[] animalIconSelect = new Sprite[5]; //0は人なので使用しない
	[SerializeField] private Sprite[] animalModeIcon = new Sprite[5];
	[SerializeField] private Animator playerAnimetor;


	private bool[] foundAnimal = new bool[5];
	public int DisplayUI = -1;//-1だったら表示されていない。

	void Start () {

	}


	void Update () {
		timer += Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.P)) {
			GameOver();
		}
		if (Input.GetKeyDown(KeyCode.O)) {
			GameClear();
		}
	}

	//新しい動物を見つけたときにプレイヤーが実行
	public void FoundAnimal(int a) {
		foundAnimal[a] = true;
		DisplayUI = a;
		if(DisplayUI != -1) {
			animalUI[DisplayUI].SetActive(false);
		}
		animalUI[a].SetActive(true);
		animalIcon[a].SetActive(true);
	}

	//魔剤を見つけたときにプレイヤーが実行
	public void FoundMazai() {
		timer -= 10;
		mazaiSum++;

	}

	//動物を切り替えたときにプレイヤーが実行,UIの切り替えをする
	public void CurrentAnimal(int a) {
		animalMode.GetComponent<Image>().sprite = animalModeIcon[a];
		playerAnimetor.SetInteger("Index", a);
		if (a!=0) animalIcon[a].GetComponent<Image>().sprite = animalIconSelect[a];
		if (CurrentAnimalNum != 0) animalIcon[CurrentAnimalNum].GetComponent<Image>().sprite = animalIconNone[CurrentAnimalNum];
		CurrentAnimalNum = a;
	}

	public void GameClear() {
		SceneManager.LoadScene("GameClear", LoadSceneMode.Additive);
		Time.timeScale = 0;
	}

	public void GameOver() {
		SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
		Time.timeScale = 0;
	}
}
