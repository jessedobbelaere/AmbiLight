//
//  AmbiColorViewController.h
//  Ambilightv2
//
//  Created by Jesse Dobbelaere on 20/05/12.
//  Copyright (c) 2012. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "ColorPickerViewController.h"

@interface AmbiColorViewController : UIViewController <ColorPickerViewControllerDelegate>
@property (weak, nonatomic) IBOutlet UIButton *ChooseColorBtn;
@property (weak, nonatomic) IBOutlet UIView *colorSwatch;

- (IBAction)chooseColor:(id)sender;

@end
