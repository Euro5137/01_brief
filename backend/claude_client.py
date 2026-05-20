import os
from typing import Any

from anthropic import Anthropic


def generate_with_claude(prompt: str, system: str | None = None) -> dict[str, Any]:
    api_key = os.getenv("ANTHROPIC_API_KEY")
    if not api_key:
        raise RuntimeError("ANTHROPIC_API_KEY is not set")

    model = os.getenv("ANTHROPIC_MODEL", "claude-sonnet-4-5")
    max_tokens = int(os.getenv("ANTHROPIC_MAX_TOKENS", "1200"))

    client = Anthropic(api_key=api_key)
    response = client.messages.create(
        model=model,
        max_tokens=max_tokens,
        system=system or "You are a precise game-content generation assistant.",
        messages=[{"role": "user", "content": prompt}],
    )

    text_parts: list[str] = []
    for block in response.content:
        if getattr(block, "type", None) == "text":
            text_parts.append(block.text)

    return {
        "model": model,
        "output_text": "\n".join(text_parts).strip(),
        "stop_reason": response.stop_reason,
        "usage": {
            "input_tokens": response.usage.input_tokens,
            "output_tokens": response.usage.output_tokens,
        },
    }
