using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DelayTest : MonoBehaviour
{
	Text txtLoading = null;
	private sbyte countDownNum = 3;
	private string[] dots = new string[]{".","..","..."};
	private int index = 0;

	void Awake()
	{
		txtLoading = gameObject.transform.Find("txtLoading").GetComponent<Text>();
	}

	void Start()
	{
		vp_Timer.In(1, CountDown,0);
	}

	private void CountDown(float deltaTime)
	{
		txtLoading.text = countDownNum--.ToString();
		if (countDownNum <= 0)
		{
			vp_Timer.In(1, Loading, 0);
			vp_Timer.Cancel(CountDown);
		}
	}

	private void Loading(float deltaTime)
	{
		string str = dots[index++ % 3];
		txtLoading.text = string.Format("Loading{0}", str);
	}

	void Update()
	{

	}

	void OnDestroy()
	{
		vp_Timer.Cancel(Loading);
	}
}