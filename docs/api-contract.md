# API Contract – v1

## Create Project
POST /api/v1/projects

Request:
{
  "title": "My Side Project",
  "description": "Description",
  "visibility": "Public"
}

Response:
201 Created
{
  "projectId": "uuid"
}

---

## React to Project
POST /api/v1/projects/{projectId}/reactions

Request:
{
  "type": "Like"
}

Response:
200 OK
{
  "likeCount": 10,
  "dislikeCount": 10,
  "loveCount": 3
}

---

## Rate Project
POST /api/v1/projects/{projectId}/ratings

Request:
{
  "score": 5
}

Response:
200 OK
{
  "average": 4.6,
  "userScore": 5
}

---

## Comment on Project
POST /api/v1/projects/{projectId}/comments

Request:
{
  "content": "Great project!",
  "parentCommentId": null
}

Response:
201 Created
{
  "commentId": "uuid"
}
