using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiskController : MonoBehaviour {

	public UI_Manager UI_Manager;
	public Sound sound;

	private Rigidbody rb;

	private int p1Score;
	private int p2Score;
	private int time;
	private float timercount;
	private int lightspawndownupcontrol;

	public GameObject p1;
	public GameObject p2;

	public GameObject redgoal;
	public GameObject bluegoal;


	public GameObject sparc_left_particle;
	public GameObject sparc_right_particle;

	public GameObject redspawnlight;
	public GameObject bluespawnlight;

	public TextMeshProUGUI bluescore;
	public TextMeshProUGUI redscore;
	public TextMeshProUGUI timertxt;



	void Start ()
	{
		rb = GetComponent<Rigidbody>();

		p1Score = 0;
		p2Score = 0;
		time = 90;
		timercount = 90;

		p1 = GameObject.FindWithTag("P1");
		p2 = GameObject.FindWithTag("P2");

		//StartCoroutine(TimerDecrease(timercount));
	}

	public void OnCollisionEnter(Collision hit)
	{
		//Yan duvarlandan çıkan efektler

		if (hit.gameObject.CompareTag("Eastwall"))
		{
			ContactPoint contact = hit.contacts[0];
			Vector3 pos = contact.point;
			var instaparticleeffect = Instantiate(sparc_left_particle, pos, Quaternion.identity);
			Destroy(instaparticleeffect, 1);
		}
		else if (hit.gameObject.CompareTag("Westwall"))
        {
			ContactPoint contact = hit.contacts[0];
			Vector3 pos = contact.point;
			var instaparticleeffect = Instantiate(sparc_right_particle, pos, Quaternion.identity);
			Destroy(instaparticleeffect, 1);
		}

		//Kaleden skor alma bölümü

		if (hit.gameObject.CompareTag("RedGoall"))
		{
			p1Score++;
			bluescore.text = p1Score.ToString();
			sound.StartCoroutine("Goll_Sound");
			Debug.Log(p1Score);
			StartCoroutine("RedSpawnPointLightandGoalControl");

		}
		else if (hit.gameObject.CompareTag("BlueGoall"))
		{
			p2Score++;
			redscore.text = p2Score.ToString();
			sound.StartCoroutine("Goll_Sound");
			Debug.Log(p2Score);
			StartCoroutine("BlueSpawnPointLightandGoalControl");
		}

        //Çarpışma Efektleri Playerla

        if (gameObject.CompareTag("Disk") && hit.gameObject.CompareTag("P1") || hit.gameObject.CompareTag("P2"))
        {
			sound.Player_hit_sound();
		}
		else if (gameObject.CompareTag("Disk") && hit.gameObject.CompareTag("Wall") || hit.gameObject.CompareTag("Westwall") || hit.gameObject.CompareTag("Eastwall"))
        {
			sound.Wall_hit_Sound();
        }
	}

    public void Update()
    {


        if (lightspawndownupcontrol == 1)
        {
			redspawnlight.transform.position = Vector3.MoveTowards(redspawnlight.transform.position, new Vector3(redspawnlight.transform.position.x, 0.45f, redspawnlight.transform.position.z), 5f * Time.deltaTime);
			p2.transform.position = Vector3.MoveTowards(p2.transform.position, new Vector3(0f, 0.55f, 5), 5f * Time.deltaTime);
		}
		else if (lightspawndownupcontrol == 2)
        {
			redspawnlight.transform.position = Vector3.MoveTowards(redspawnlight.transform.position, new Vector3(redspawnlight.transform.position.x, 2.2f, redspawnlight.transform.position.z), 5f * Time.deltaTime);
			p2.transform.position = Vector3.MoveTowards(p2.transform.position, new Vector3(0f, 0.55f, 5), 5f * Time.deltaTime);
		}
		else if (lightspawndownupcontrol == 3)
        {
			bluespawnlight.transform.position = Vector3.MoveTowards(bluespawnlight.transform.position, new Vector3(bluespawnlight.transform.position.x, 0.45f, bluespawnlight.transform.position.z), 5f * Time.deltaTime);
		}
		else if (lightspawndownupcontrol == 4)
		{
			bluespawnlight.transform.position = Vector3.MoveTowards(bluespawnlight.transform.position, new Vector3(bluespawnlight.transform.position.x, 2.2f, bluespawnlight.transform.position.z), 5f * Time.deltaTime);
		}


	}

    public void LateUpdate()
    {
        if (gameObject.transform.position.x <= -5.93 || gameObject.transform.position.x >= 6.02f)
        {
			StartCoroutine("BlueSpawnPointLightandGoalControl");
		}
    }

	public void TimeDecreasefunc()
    {
		StartCoroutine(TimerDecrease(timercount));
	}

    public IEnumerator TimerDecrease(float timercount)
	{

		for (timercount = time; timercount > 0f; timercount -= 0.02f)
		{
			timertxt.text = timercount.ToString("F2");
			yield return new WaitForSeconds(0.01f);
			Debug.Log(timercount);

			//Oyunun bittiği yer
			if (timercount <= 0.5f)
			{
				Debug.Log("Game Finished");

				if (p1Score > p2Score)
				{
					Debug.Log("Blue win");
					UI_Manager.GetComponent<UI_Manager>().FinishWinStartfunc();

				}
				else if (p2Score > p1Score)
				{
					Debug.Log("Red win");
					UI_Manager.GetComponent<UI_Manager>().FinishLoseStartfunc();
				}
				else
				{
					Debug.Log("Draw");
					UI_Manager.GetComponent<UI_Manager>().FinishDrawStartfunc();
				}

			}
		}



	}



	//-------------------------Işıkların Aşağı Yukarı Hareketi ve Disklerin Golden sonra Oluşması

	public IEnumerator RedSpawnPointLightandGoalControl()
	{
		Variables.diskmovecontrol = true;
		rb.velocity = new Vector3(0, 0, 0);
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		gameObject.transform.position = new Vector3(0.03f, 0.542f, 1.73f);

		//2.2 => 0.45 ye doğru gidip gelcek
		lightspawndownupcontrol = 1;
		yield return new WaitForSecondsRealtime(0.7f);
		lightspawndownupcontrol = 2;
		gameObject.GetComponent<MeshRenderer>().enabled = true;
		yield return new WaitForSecondsRealtime(0.7f);
		lightspawndownupcontrol = 0;
		Variables.diskmovecontrol = false;
	}


	public IEnumerator BlueSpawnPointLightandGoalControl()
    {
		rb.velocity = new Vector3(0, 0, 0);
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		gameObject.transform.position = new Vector3(0.03f, 0.542f, -3.03f);

		//2.2 => 0.45 ye doğru gidip gelcek
		lightspawndownupcontrol = 3;
		yield return new WaitForSecondsRealtime(0.7f);
		lightspawndownupcontrol = 4;
		gameObject.GetComponent<MeshRenderer>().enabled = true;
		yield return new WaitForSecondsRealtime(0.7f);
		lightspawndownupcontrol = 0;

	}







}



	




