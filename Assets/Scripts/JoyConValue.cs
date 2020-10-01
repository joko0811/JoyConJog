using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JoyConValue : MonoBehaviour
{
    private static readonly Joycon.Button[] m_buttons =
        Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];

    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    //private Joycon m_joyconR;
    private Joycon.Button? m_pressedButtonL;
    //private Joycon.Button? m_pressedButtonR;

    private List<float> accelLog = new List<float>();

    public bool graphMode = false;

    private void Start()
    {
        m_joycons = JoyconManager.Instance.j;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        m_joyconL = m_joycons.Find(c => c.isLeft);
        //m_joyconR = m_joycons.Find(c => !c.isLeft);
    }

    private void Update()
    {
        m_pressedButtonL = null;
        //m_pressedButtonR = null;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        foreach (var button in m_buttons)
        {
            if (m_joyconL.GetButton(button))
            {
                m_pressedButtonL = button;
            }
            //if (m_joyconR.GetButton(button))
            //{
            //    m_pressedButtonR = button;
            //}
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_joyconL.SetRumble(160, 320, 0.6f, 200);
        }
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    m_joyconR.SetRumble(160, 320, 0.6f, 200);
        //}
    }

    private void OnGUI()
    {
        if (!graphMode)
        {
            var style = GUI.skin.GetStyle("label");
            style.fontSize = 24;

            if (m_joycons == null || m_joycons.Count <= 0)
            {
                GUILayout.Label("Joy-Con が接続されていません");
                return;
            }

            if (!m_joycons.Any(c => c.isLeft))
            {
                GUILayout.Label("Joy-Con (L) が接続されていません");
                return;
            }

            //if (!m_joycons.Any(c => !c.isLeft))
            //{
            //    GUILayout.Label("Joy-Con (R) が接続されていません");
            //    return;
            //}

            GUILayout.BeginHorizontal(GUILayout.Width(960));

            foreach (var joycon in m_joycons)
            {
                var isLeft = joycon.isLeft;
                var name = isLeft ? "Joy-Con (L)" : "Joy-Con (R)";
                var key = isLeft ? "Z キー" : "X キー";
                //var button = isLeft ? m_pressedButtonL : m_pressedButtonR;
                var button = m_pressedButtonL;
                var stick = joycon.GetStick();
                var gyro = joycon.GetGyro();
                var accel = joycon.GetAccel();
                var orientation = joycon.GetVector();


                GUILayout.BeginVertical(GUILayout.Width(480));
                GUILayout.Label(name);
                GUILayout.Label(key + "：振動");
                GUILayout.Label("押されているボタン：" + button);
                GUILayout.Label(string.Format("スティック：({0}, {1})", stick[0], stick[1]));
                GUILayout.Label("ジャイロ：" + gyro);
                GUILayout.Label("加速度：" + accel);
                GUILayout.Label("傾き：" + orientation);
                GUILayout.EndVertical();
            }

            GUILayout.EndHorizontal();
        }
        else
        {
            //加速度グラフ描画

            var area = GUILayoutUtility.GetRect(Screen.width, Screen.height);

            // Grid
            const int div = 10;
            for (int i = 0; i <= div; ++i)
            {
                var lineColor = (i == 0 || i == div) ? Color.white : Color.gray;
                var lineWidth = (i == 0 || i == div) ? 2f : 1f;
                var x = (area.width / div) * i;
                var y = (area.height / div) * i;
                Drawing.DrawLine(
                    new Vector2(area.x + x, area.y),
                    new Vector2(area.x + x, area.yMax), lineColor, lineWidth, true);
                Drawing.DrawLine(
                    new Vector2(area.x, area.y + y),
                    new Vector2(area.xMax, area.y + y), lineColor, lineWidth, true);
            }

            // Data
            if (accelLog.Count > 0)
            {
                var max = accelLog.Max();
                var dx = area.width / accelLog.Count;
                var dy = area.height / max;
                Vector2 previousPos = new Vector2(area.x, area.yMax);
                for (var i = 0; i < accelLog.Count; ++i)
                {
                    var x = area.x + dx * i;
                    var y = area.yMax - dy * accelLog[i];
                    var currentPos = new Vector2(x, y);
                    Drawing.DrawLine(previousPos, currentPos, Color.red, 3f, true);
                    previousPos = currentPos;
                }
            }
        }
    }
}
