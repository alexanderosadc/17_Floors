var scrollArea = 5;
var scrollSpeed = 100;
var acceleration = 5;

var scrollX = true;
var scrollY = false;

@HideInInspector
var maxScrollSpeed = scrollSpeed;
@HideInInspector
var moving = false;

function Start() {
    if (acceleration > 0) {
        maxScrollSpeed = scrollSpeed;
        scrollSpeed = 0;
    }
}

function Update() {
    var mPosX = Input.mousePosition.x;
    var mPosY = Input.mousePosition.y;
    var normalizer = 0.05;

    moving = false;

    // Do camera movement by mouse position
    if (scrollX) {
        if (mPosX < scrollArea) {
            transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime * normalizer);
            moving = true;
        }

        if (mPosX >= Screen.width-scrollArea) {
            transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime * normalizer);
            moving = true;
        }
    }
    
    if (scrollY) {
        if (mPosY < scrollArea) {
            transform.Translate(Vector3.up * -scrollSpeed * Time.deltaTime * normalizer);
            moving = true;
        }

        if (mPosY >= Screen.height-scrollArea) {
            transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime * normalizer);
            moving = true;
        }
    }

    if (moving) {
        if (acceleration > 0 && scrollSpeed <= maxScrollSpeed) {
            scrollSpeed += acceleration * Time.deltaTime * (normalizer * maxScrollSpeed);

            if(scrollSpeed > maxScrollSpeed)
                scrollSpeed = maxScrollSpeed;
        }
    } else if (acceleration > 0) {
        scrollSpeed = 0;
    }

}