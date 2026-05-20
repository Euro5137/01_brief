from fastapi import FastAPI

app = FastAPI(title="backend")


@app.get("/")
def healthcheck() -> dict[str, str]:
    return {"status": "ok"}
