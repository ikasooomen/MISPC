using System;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;


namespace Com.MyCompany.MyGame
{

    public class Launcher : MonoBehaviourPunCallbacks
    {
        #region Private Serializable Fields
        #endregion

        #region Private Fields

        /// <summary>
        /// This client`s version number. Users are separated from each other by gameVersion(which allows you to make breaking changers).
        /// </summary>
        string gameVersion = "1";
        #endregion

        #region  Monobihaviour CallBackes

        public override void OnConnectedToMaster()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
            //#Critical: The first we try to do is to hoin a potential existing room.If there is, good, else, we'll be called back with OnJoinRandomFailed()
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was Called by PUN with reason {0}", cause);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

            // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
            PhotonNetwork.CreateRoom(null, new RoomOptions());
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        }
        #endregion

        private void Awake()
        {
            //#Critical
            //this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
            PhotonNetwork.AutomaticallySyncScene = true;
        }
        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during initialization
        /// </summary>
        void Start()
        {
            Connect();
        }

        #region Public Methods

        /// <summary>
        /// Start the connection process.
        ///  If already connected,we attempt joining a random room
        ///  If not yet connected,Connect this application instance to Photon Cloud
        /// </summary>
        void Connect()
        {
            //we check if we are connected or not, we hoin if we are , else we initialize
            if (PhotonNetwork.IsConnected)
            {
                //#Critical we need at this point ot attempt hoining a Random Room.
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                //#Critical, we must first and foremost connect to Photon Online Serer
                //PhotonNetwork.GemeVersion = gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }

        }

        #endregion
    }
}