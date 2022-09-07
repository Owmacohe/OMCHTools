# OMCHTools

***A collection of utility methods/techniques that I use for mundane Unity tasks, organized in one place!***



## File

**For reading array data from various types of TextAssets.**

> #### TXTToArray
>
> - Converts a given TextAsset / a TextAsset in the Resources folder into a array of lines
> - Works for string, int, float or Vector3
> - `null` if the file is empty

> #### CSVToMatrix
>
> - Converts a **given** TextAsset / a TextAsset in the Resources folder into a 2D matrix of cells
> - Works for string, int, float or Vector3
> - `null` if the file is empty



## Component

**For manipulating/removing/extracting Components from GameObjects.**

> #### RemoveAllComponents
>
> Removes all Components of the given type from the given GameObject and all its children.

> #### AddAllComponents
>
> Adds a Component of the given type to the given GameObject and all its children.

> #### GetAllComponents
>
> Gets all Components of the given type from the given GameObject and all its children.

> #### SetAllRendererMaterials
>
> Sets the Material of each type of Renderer / the given type of Renderer on the given GameObject and all its children.

> #### SetAllRendererColors
>
> Sets the Color of the Material of each type of Renderer / the given type of Renderer on the given GameObject and all its children.

> #### SetLocalMeshVertices
>
> Sets the local mesh vertices of a given GameObject's MeshFilter.

> #### SetGlobalMeshVertices
>
> Sets the global mesh vertices of a given GameObject's MeshFilter.

> #### GetLocalMeshVertices
>
> - Gets the local mesh vertices of a given gameObject's MeshFilter
> - `null` if it doesn’t have a mesh

> #### GetGlobalMeshVertices
>
> - Gets the global mesh vertices of a given gameObject's MeshFilter
> - `null` if it doesn’t have a mesh



## Bounds

**For getting Bounds properties of GameObjects.**

> #### GetGlobalCenter
>
> - Gets the local center of the given GameObject's MeshFilter's bounds
> - `Vector3.zero` if it doesn’t have a mesh

> #### GetLocalCenter
>
> - Gets the global center of the given GameObject's MeshFilter's bounds
> - `obj.transform.position` if it doesn’t have a mesh

> #### GetGlobalScale
>
> - Gets the local scale of the given GameObject's MeshFilter's bounds
> - `Vector3.zero` if it doesn’t have a mesh

> #### GetLocalScale
>
> - Gets the global scale of the given GameObject's MeshFilter's bounds
> - `obj.transform.localScale` if it doesn’t have a mesh



## Array

**For manipulating arrays.**

> #### Vector3ToGlobal
>
> - Converts a local Vector3 array to a global one, based on the given GameObject
> - `null` if array is null

> #### Vector3ToLocal
>
> - Converts a global Vector3 array to a local one, based on the given GameObject
> - `null` if array is null

> #### FloatRound
>
> - Rounds each element in a float array to a certain number of decimal places
> - `null` if array is null
