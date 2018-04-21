using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestCases0
{

	[Test]
	public void TestCases0SimplePasses()
	{
		// Use the Assert class to test conditions.
		Assert.AreEqual(true, true);
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator TestssWithEnumeratorPasses()
	{
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}

	[UnityTest]
	public IEnumerator TestssWithEnumeratorEnemySpawn()
	{
		// Use the Assert class to test conditions.
		// yield to skip a frame
		var spawnedEnemy = GameObject.FindGameObjectWithTag("Enemy");




		yield return null;
	}



	[UnityTest]
	public IEnumerator TestssWithEnumeratorEnemySpawn2()
	{
		// Use the Assert class to test conditions.
		// yield to skip a frame
		var go = new GameObject("JA");

		Assert.AreEqual("JA", go.name);




		yield return null;
	}


	[Test]
	[UnityPlatform(RuntimePlatform.OSXPlayer)]
	public void TestMethod1()
	{
		Assert.AreEqual(Application.platform, RuntimePlatform.OSXPlayer);
	}

	[Test]
	[UnityPlatform(exclude = new[] { RuntimePlatform.OSXEditor })]
	public void TestMethod2()
	{
		Assert.AreNotEqual(Application.platform, RuntimePlatform.OSXEditor);
	}

	[Test]
	public void LogAssertExample()
	{
		//Expect a regular log message
		LogAssert.Expect(LogType.Log, "Log message");
		//A log message is expected so without the following line
		//the test would fail
		Debug.Log("Log message");
		//An error log is printed
		Debug.LogError("Error message");
		//Without expecting an error log, the test would fail
		LogAssert.Expect(LogType.Error, "Error message");
	}
}
