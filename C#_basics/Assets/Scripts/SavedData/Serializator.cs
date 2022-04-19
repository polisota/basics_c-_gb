using System.Xml.Serialization;
using System;
using System.IO;

public class Serializator
{
	static public void SaveXml(LevelState state, string datapath)
	{
		Type[] extraTypes = { typeof(BonusData), typeof(GBonus) };
		XmlSerializer serializer = new XmlSerializer(typeof(LevelState), extraTypes);

		FileStream fs = new FileStream(datapath, FileMode.Create);
		serializer.Serialize(fs, state);
		fs.Close();

	}

	static public LevelState DeXml(string datapath)
	{
		Type[] extraTypes = { typeof(BonusData), typeof(GBonus) };
		XmlSerializer serializer = new XmlSerializer(typeof(LevelState), extraTypes);

		FileStream fs = new FileStream(datapath, FileMode.Open);
		LevelState state = (LevelState)serializer.Deserialize(fs);
		fs.Close();

		return state;
	}
}