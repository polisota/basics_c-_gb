using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;

[XmlType("BonusData")]
[XmlInclude(typeof(GBonus))]

public class BonusData
{
	protected GameObject _inst;
	public GameObject inst { set { _inst = value; } }

	[XmlElement("Type")]
	public string Name { get; set; }

	[XmlElement("Position")]
	public Vector3 position { get; set; }

	public BonusData() { }

	public BonusData(string name, Vector3 position)
	{
		this.Name = name;
		this.position = position;
	}

	public virtual void Estate() { }

	public virtual void Update()
	{  
		position = _inst.transform.position;
	}

}

[XmlType("GBonus")]
public class GBonus : BonusData
{
	[XmlAttribute("SetAct")]
	public bool setActOn { get; set; }

	public GBonus() { }

	public GBonus(string name, Vector3 position, bool setActOn) : base(name, position)
	{
		this.setActOn = setActOn;
	}

	public override void Estate()
	{
		if (!setActOn) ((MeshRenderer)(_inst.GetComponentInChildren(typeof(MeshRenderer)))).enabled = false;
	}        

	public override void Update()
	{
		base.Update();
		setActOn = ((MeshRenderer)_inst.GetComponentInChildren(typeof(MeshRenderer))).enabled;
	}  
}
