# 01_brief

Vibe coding quickstart workspace.

## Environment check

- Node.js: `node --version`
- npm: `npm --version`
- pnpm: `pnpm --version`
- yarn: `yarn --version`
- Python: `python --version`
- pip: `pip --version`
- uv: `uv --version`

## Quick start

### Run both apps

```bash
npm install
npm run dev
```

- Frontend: `http://localhost:5173`
- Backend: `http://127.0.0.1:8000`
- Health check: `http://127.0.0.1:8000/health`

### Run separately

```bash
npm run dev:frontend
```

```bash
npm run dev:backend
```

### Local checks

```bash
npm run check
```

### Backend env

Copy `backend/.env.example` to `backend/.env` and edit if needed.

## Claude + Unity integration (recommended)

Architecture:
- Unity (C#) -> FastAPI backend -> Claude API
- Keep API keys only in backend (`backend/.env`)

### 1) Configure backend env

Set in `backend/.env`:
- `ANTHROPIC_API_KEY`
- `ANTHROPIC_MODEL` (default: `claude-sonnet-4-5`)
- `ANTHROPIC_MAX_TOKENS`

### 2) Start backend

```bash
npm run dev:backend
```

### 3) Call generation endpoint

`POST /generate`

Example body:

```json
{
  "prompt": "Create a short JSON quest with title, objective, reward.",
  "system": "Return concise, game-friendly content."
}
```

### 4) Unity client sample

Use `unity-sample/ClaudeBackendClient.cs` in your Unity project.
It sends HTTP POST to backend and parses the generated text response.
