PointNClick
===========

Complete documentation is provided in the “Documentation” folder inside the main project folder. Click “classes” to see a list of the classes.
I strived to create a generic “engine” rather than a specific game, hence the throw-away graphics. The focus was on the code rather than the graphics.
---------------------
GameXML is the Model class that contains most of the game state loaded from XML.

GameController is the controller for GameXML as well as all other controllers. It doesn’t have (or need) a specific view on its own. 

Inventory is managed through pure MVC (InventoryController, InventoryView, and InventoryItem. The game controller talks to the Inventory Controller to manage Inventory.

InputManager is a generic “input” handling layer that unifies input (touch, mouse) and passes its input  to GameController. GameController then proceeds to find which Item was clicked and takes appropriate action, calling upon InventoryController etc to do its bidding.

Item,PickableItem, and NavigationItem are used the various kinds of objects that the user can interact with in the scene.
SaveLoad is a helper class that manages the saving/loading for the whole engine. It is Static and accessible from anywhere. It doesn’t have any dependencies, and other classes are encapsulated from it.
