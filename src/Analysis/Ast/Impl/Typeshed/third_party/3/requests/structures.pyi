# Stubs for requests.structures (Python 3)

from typing import Any, Iterator, MutableMapping, Tuple, Union

class CaseInsensitiveDict(MutableMapping[str, Union[str, bytes]]):
    def lower_items(self) -> Iterator[Tuple[str, Union[str, bytes]]]: ...

class LookupDict(dict):
    name = ...  # type: Any
    def __init__(self, name=...) -> None: ...
    def __getitem__(self, key): ...
    def get(self, key, default=...): ...