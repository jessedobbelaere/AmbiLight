//
//  AmbiColorViewController.m
//  Ambilightv2
//
//  Created by Jesse Dobbelaere on 20/05/12.
//  Copyright (c) 2012. All rights reserved.
//

#import "AmbiColorViewController.h"
#import "ColorPickerViewController.h"
#import "AmbiConnection.h"

@interface AmbiColorViewController ()

@end

@implementation AmbiColorViewController
@synthesize ChooseColorBtn;
@synthesize colorSwatch;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view.
    
    NSLog(@"Nieuwe view geladen");  
}

- (void)viewDidUnload
{
    [self setChooseColorBtn:nil];
    [self setColorSwatch:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

- (IBAction)chooseColor:(id)sender {
    // Make a new ColorPickerViewController with the interface defined in the referenced nib:
    ColorPickerViewController *colorPickerViewController = 
    [[ColorPickerViewController alloc] initWithNibName:@"ColorPickerViewController" bundle:nil];
    
    // The ColorPickerViewController needs a delegate to send the results back to.
    // Here, we'll use self, and implement (colorPickerViewController: didSelectColor:) below.
    colorPickerViewController.delegate = self;

    // The defaults key helps you keep track of the color we're supposed to be selecting
    colorPickerViewController.defaultsColor = colorSwatch.backgroundColor;
    
    // Slides the color picker view in place.
    [self presentModalViewController:colorPickerViewController animated:YES];    

}

// Delegate method handling the result
- (void)colorPickerViewController:(ColorPickerViewController *)colorPicker didSelectColor:(UIColor *)color { 
    // Stel view in met bgcolor
    colorSwatch.backgroundColor = color;
    
    
    // Bepaal RGB waarden
    CGColorRef colorRef = [color CGColor];
    int _countComponents = CGColorGetNumberOfComponents(colorRef);
    
    if (_countComponents == 4) {
        const CGFloat *_components = CGColorGetComponents(colorRef);
        CGFloat red     = _components[0];
        CGFloat green   = _components[1];
        CGFloat blue    = _components[2];
        
        NSString *rgbMessage = [NSString stringWithFormat:@"rgb:%d,%d,%d", (int)(red*255),(int)(green*255),(int)(blue*255)];
        NSLog(@"%@", rgbMessage);
        AmbiConnection *ambiConnection = [AmbiConnection sharedConnection];
        [ambiConnection sendMessage:rgbMessage];
        
    }
    
    [colorPicker dismissModalViewControllerAnimated:YES];
}

@end
