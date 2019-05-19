﻿namespace KeyforgeNetwork
{
	public enum PacketType : ushort
	{
		Exit,
		Error,
		VersionRequest,
		VersionResponse,
		LoginRequest,
		LoginResponse,
		PlayerListRequest,
		PlayerListResponse,
		GlobalChatRequest,
		GlobalChatResponse,
		LobbyListRequest,
		LobbyListResponse,
		CreateLobbyRequest,
		CreateLobbyResponse,
		JoinLobbyRequest,
		JoinLobbyResponse,
		LeaveLobbyRequest,
		LeaveLobbyResponse,
		KickLobbyRequest,
		KickLobbyResponse,
		BanLobbyRequest,
		BanLobbyResponse,
		ConcedeGameRequest,
		ConcedeGameResponse,
		SelectDeckRequest,
		SelectDeckResponse,
		ReadyRequest,
		ReadyResponse,
		StartGameRequest,
		StartGameResponse,
		LeaveGameRequest,
		LeaveGameResponse,
		UpdateGameState,
		MulliganRequest,
		MulliganResponse,
		CardPileRequest,
		CardPileResponse,
		DrawCardRequest,
		DrawCardResponse,
		PlayCardRequest,
		PlayCardResponse,
		DiscardCardRequest,
		DiscardCardResponse,
		UseCardRequest,
		UseCardResponse,
        LobbyChatRequest,
        LobbyChatResponse
    }

    public class Protocol
    {
        public  static float Version = 0.01f;
    }
}