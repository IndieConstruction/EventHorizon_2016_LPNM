using UnityEngine;
using System.Collections;
namespace EH.LPNM{
public interface IRoad{

	GameObject Road {
		get;
		set;
	}
	Vector3 PositionToSpawn{
		get;
		set;
	}

	void Spawn(GameObject objectToSpawn, Vector3 positionToSpawn);

		
	
}
}