using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;


[XmlRoot("LevelState")]
[XmlInclude(typeof(BonusData))]

public class LevelState
{
	[XmlArray("Bonus")]	
	public List<BonusData> bonus = new List<BonusData>();

	public LevelState() { }

	public void AddItem(BonusData item)
	{   
		bonus.Add(item);
	}

	public void Update()
	{   
		foreach (BonusData felt in bonus)
		felt.Update();
	}
}
