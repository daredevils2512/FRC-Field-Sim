using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RobotNetworkManager : NetworkManager {
	public override void OnServerAddPlayer (NetworkConnection conn, short playerControllerId)
	{
		base.OnServerAddPlayer (conn, playerControllerId);

		PlayerNetworked player = conn.playerControllers [0].gameObject.GetComponent<PlayerNetworked>();

		SpawnRobot (player.robot,conn);
	}
	public void SpawnRobot(RobotNetworked robot, NetworkConnection conn){
		NetworkServer.SpawnWithClientAuthority (robot.gameObject,conn);
	}
}
