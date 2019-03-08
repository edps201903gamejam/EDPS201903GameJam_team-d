using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	private int currentStageNum;//0はタイトル
	private float timer;
	private int mazaiSum;
	private int CurrentAnimalNum;
	private GameObject[] animalUI = new GameObject[5];
	private GameObject[] animalIcon = new GameObject[5]; //0は人なので使用しない
	private GameObject animalMode;
	[SerializeField] private Sprite[] animalIconNone = new Sprite[5]; //0は人なので使用しない
	[SerializeField] private Sprite[] animalIconSelect = new Sprite[5]; //0は人なので使用しない
	[SerializeField] private Sprite[] animalModeIcon = new Sprite[5];
	private Animator playerAnimetor;

	private bool[] _foundAnimal = new bool[5];
	private bool[] _clearStage = new bool[3];
	public int DisplayUI = -1;//-1だったら表示されていない。
	void Awake() {
		if(1 < GameObject.FindGameObjectsWithTag("GameController").Length) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this);
	}
	private void Start()
	{
		_foundAnimal[0] = true;
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void Update () {
		timer += Time.deltaTime;
	}

	//新しい動物を見つけたときにプレイヤーが実行
	public void FoundAnimal(int a) {
		_foundAnimal[a] = true;
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

		if (CurrentAnimalNum != 0) animalIcon[CurrentAnimalNum].GetComponent<Image>().sprite = animalIconNone[CurrentAnimalNum];
		if (a!=0) animalIcon[a].GetComponent<Image>().sprite = animalIconSelect[a];
		CurrentAnimalNum = a;
	}

	//シーン切り替え用関数
	public void ChangeStage(int s) {
		currentStageNum = s;
		if (s == 0) SceneManager.LoadScene("Title");
		else SceneManager.LoadScene("Stage" + s.ToString());
	}

	//シーンの読み込みが終わったら、実行される関数
	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		Debug.Log(currentStageNum);
		if (currentStageNum == 0) {
			GameObject SS = GameObject.Find("StageSelect");
			SS.GetComponent<StageSelectController>().SetStageSelect();
		}
		if (0 < currentStageNum) {
			Debug.Log(scene.name + " scene loaded");
			Debug.Log(SceneManager.GetActiveScene());
			playerAnimetor = GameObject.Find("kyoko0").GetComponent<Animator>();
			animalMode = GameObject.Find("Canvas/PlayerStatus/ModeIcon");
			GameObject au = GameObject.Find("Canvas/Animal");
			GameObject ai = GameObject.Find("Canvas/PlayerStatus/AnimalIcon");
			for (int i = 0; i < 5; i++) {
				animalUI[i] = au.transform.GetChild(i).gameObject;
				if (i != 4) animalIcon[i+1] = ai.transform.GetChild(i).gameObject;
			}
		}
	}


	public void GameClear() {
		_clearStage[currentStageNum-1] = true;
		currentStageNum = -1;
		SceneManager.LoadScene("GameClear", LoadSceneMode.Additive);
		Time.timeScale = 0;
	}

	public void GameOver() {
		currentStageNum = -1;
		SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
		Time.timeScale = 0;
	}

	public bool[] FoundAnimalList {
		get {
			return _foundAnimal;
		}
	}

	public bool[] ClearStageList {
		get {
			return _clearStage;
		}
	}
}
