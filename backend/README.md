# Backend (FastAPI + Claude)

## Setup

1. Copy `.env.example` to `.env`
2. Set `ANTHROPIC_API_KEY` in `.env`
3. Run server:

```bash
uv run uvicorn main:app --reload --host 127.0.0.1 --port 8000
```

## Endpoints

- `GET /health` - health check
- `POST /generate` - Claude generation

Example request body:

```json
{
  "prompt": "Create a short JSON quest with title, objective, reward.",
  "system": "Return concise, game-friendly content."
}
```
