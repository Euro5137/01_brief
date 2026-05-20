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
