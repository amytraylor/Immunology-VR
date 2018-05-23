using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
	static public int  Minutes = 15;
	static public int  Seconds = 0;

	public Text    m_text;
	public float   m_leftTime;

    public bool isCountDownStart;

	private void Awake()
	{
		m_text = GetComponent<Text>();
		m_leftTime = GetInitialTime();
	}

	private void Update()
	{
		if (m_leftTime > 0f && isCountDownStart)
		{
			//  Update countdown clock
			m_leftTime -= Time.deltaTime;
			Minutes = GetLeftMinutes();
			Seconds = GetLeftSeconds();

			//  Show current clock
			if (m_leftTime > 0f)
			{
				m_text.text = Minutes + ":" + Seconds.ToString("00");
			}
			else
			{
				//  The countdown clock has finished
				m_text.text = "0:00";
			}
		}
	}

	private float GetInitialTime()
	{
		return Minutes * 60f + Seconds;
	}

	private int GetLeftMinutes()
	{
		return Mathf.FloorToInt(m_leftTime / 60f);
	}

	private int GetLeftSeconds()
	{
		return Mathf.FloorToInt(m_leftTime % 60f);
	}
}