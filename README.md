# A collaborative music playlist application. 
Users can create playlists, add songs, and collaborate on music choices.

# Endpoints of the project:

#### User Registration and Authentication:
* [POST] /api/auth/register: Register a new user with email and password.
* [POST] /api/auth/login: Authenticate and generate a JWT token for a user.

#### Playlists:
* [POST] /api/playlists: Create a new playlist (requires authentication).
* [POST] /api/playlists/{playlistId}/songs: Add a song to a playlist (requires authentication).
* [GET] /api/playlists/{playlistId}/songs: Get a list of songs in a playlist.
* [DELETE] /api/playlists/{playlistId}/songs/{songId}: Delete a song from a playlist (requires authentication).
* [PUT] /api/playlists/{playlistId}/songs/{songId}: Update a song in a playlist (requires authentication).
* [DELETE] /api/playlists/{playlistId}: Delete a playlist (requires authentication).
* [PUT] /api/playlists/{playlistId}: Update a playlist (requires authentication).

#### Collaborative Playlists:
* [GET] /api/playlists: Get a list of all available playlists.
* [GET] /api/playlists/{playlistId}: Get details of a specific playlist.
* [POST] /api/playlists/{playlistId}/join: Join a collaborative playlist (requires authentication).
* [POST] /api/playlists/{playlistId}/songs: Add a song to a collaborative playlist (requires authentication and playlist membership).
* [POST] /api/playlists/{playlistId}/vote: Vote on a song in a collaborative playlist (requires authentication and playlist membership).
* [PUT] /api/playlists/{playlistId}/reorder: Reorder the songs in a collaborative playlist (requires authentication and playlist membership).
* [DELETE] /api/playlists/{playlistId}/leave: Leave a collaborative playlist (requires authentication and playlist membership).
* [DELETE] /api/playlists/{playlistId}/songs/{songId}: Delete a song from a collaborative playlist (requires authentication and playlist membership).
* [PUT] /api/playlists/{playlistId}/songs/{songId}: Update a song in a collaborative playlist (requires authentication and playlist membership).

#### Playlist Sharing and Discovery:

* [GET] /api/users/{userId}/playlists: Get playlists created by a specific user.
* [GET] /api/playlists/{playlistId}/songs: Get songs in a specific playlist.
* [GET] /api/playlists/{playlistId}/followers: Get followers of a specific playlist.
* [POST] /api/playlists/{playlistId}/follow: Follow a playlist (requires authentication).
* [DELETE] /api/playlists/{playlistId}/follow: Unfollow a playlist (requires authentication).
* [GET] /api/playlists/{playlistId}/followers/{userId}: Check if a user is following a playlist.
* [GET] /api/playlists/{playlistId}/followers/{userId}/songs: Get songs in a playlist followed by a user.
* [GET] /api/playlists/{playlistId}/followers/{userId}/playlists: Get playlists followed by a user.
* [GET] /api/playlists/{playlistId}/followers/{userId}/playlists/{followedPlaylistId}: Check if a user is following a playlist followed by another user.
* [GET] /api/playlists/{playlistId}/followers/{userId}/playlists/{followedPlaylistId}/songs: Get songs in a playlist followed by another user.
* [GET] /api/playlists/{playlistId}/followers/{userId}/playlists/{followedPlaylistId}/followers: Get followers of a playlist followed by another user.
* [GET] /api/playlists/{playlistId}/followers/{userId}/playlists/{followedPlaylistId}/followers/{followerId}: Check if a user is following a playlist followed by another user.
* [GET] /api/playlists/{playlistId}/followers/{userId}/playlists/{followedPlaylistId}/followers/{followerId}/songs: Get songs in a playlist followed by another user followed by another user.

## Technological stack:
- C#
- ASP.NET Core 
- EntityFramework Core, PostgreSQL, Redis
- RabbitMQ
- Docker